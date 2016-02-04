using System.Web.Mvc;
using GoForIt.Models;
using Newtonsoft.Json;

namespace GoForIt.Controllers
{
    public class ActionsController : Controller
    {
        [OutputCache(NoStore = true)]
        public ActionResult List()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Actions.json"));

            var data = JsonConvert.DeserializeObject<EventViewModel[]>(fileContents);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}