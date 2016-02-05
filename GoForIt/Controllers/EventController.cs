using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GoForIt.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace GoForIt.Controllers
{
    public class EventController : ApiController
    {
        // POST api/values
        public void Post([FromBody] Event value)
        {
            var path = Path.Combine(ConfigurationManager.AppSettings["eventStore"],
                DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));

            GlobalHost.ConnectionManager.GetHubContext<EventLogHub>().Clients.All.newEvent(JsonConvert.SerializeObject(value));

            Task.Factory.StartNew(() => RouteEvent(value));
        }

        private void RouteEvent(Event value)
        {
            var data = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["flowsPath"]);

            var flows = JsonConvert.DeserializeObject<List<FlowModel>>(data);

            flows
                .Where(flow => flow.EventApplication.Equals(value.Application, StringComparison.InvariantCultureIgnoreCase) && flow.EventName.Equals(value.Name, StringComparison.InvariantCultureIgnoreCase))
                .ToList()
                .ForEach(flow => ExecuteAction(flow, value));
        }

        private void ExecuteAction(FlowModel flow, Event value)
        {
            foreach (var eventParameter in value.Parameters)
            {
                var eventParameterCriteria =
                    flow.EventParameters.SingleOrDefault(
                        ep => ep.Name.Equals(eventParameter.Name, StringComparison.InvariantCultureIgnoreCase));

                if (eventParameterCriteria == null)
                {
                    Debug.WriteLine("Parameter " + eventParameter.Name + " was not found on flow");
                    return;
                }

                if (!string.IsNullOrEmpty(eventParameterCriteria.Value) && eventParameterCriteria.Value != "null")
                {
                    if (!eventParameter.Value.ToLower().Contains(eventParameterCriteria.Value.ToLower()))
                    {
                        Debug.WriteLine("Parameter " + eventParameter.Name + " did not contain expected value " + eventParameterCriteria.Value);
                        return;
                    }
                }
            }

            var action = new EventAction
            {
                Name = flow.ActionName,
                Application = flow.ActionApplication,
                Parameters = flow.ActionParameters
            };
            
            GlobalHost.ConnectionManager.GetHubContext<EventLogHub>().Clients.All.newAction(JsonConvert.SerializeObject(action));
        }
    }
}