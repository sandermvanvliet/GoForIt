using System.Web.Mvc;
using GoForIt.Models;
using Newtonsoft.Json;

namespace GoForIt.Controllers
{
    public class EventsController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0)]
        public JsonResult List()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Events.json"));

            var data = JsonConvert.DeserializeObject<EventViewModel[]>(fileContents);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}