using System.Configuration;
using System.IO;
using System.Web.Http;
using Newtonsoft.Json;

namespace Routing.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        // POST api/values
        public void Post([FromBody] Event value)
        {
            var path = Path.Combine(ConfigurationManager.AppSettings["eventStore"],
                value.Timestamp.ToUniversalTime().ToString("yyyyMMddHHmmss") + ".json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));
        }
    }
}