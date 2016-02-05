using System;
using System.Configuration;
using System.IO;
using System.Web.Http;
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
        }
    }
}