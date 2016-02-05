using System.Web.Mvc;
using GoForIt.Models;
using Newtonsoft.Json;

namespace GoForIt.Controllers
{
    public class ActionsController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult List()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Actions.json"));

            var data = JsonConvert.DeserializeObject<ApplicationEventsViewModel[]>(fileContents);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}