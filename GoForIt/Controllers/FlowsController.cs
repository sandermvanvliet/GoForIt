using System.Web.Mvc;
using GoForIt.Models;
using Newtonsoft.Json;

namespace GoForIt.Controllers
{
    public class FlowsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult New()
        {
            return View();
        }

        public JsonResult Add()
        {
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        }
        
        [OutputCache(NoStore = true)]
        public JsonResult List()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Flows.json"));

            var data = JsonConvert.DeserializeObject<FlowModel[]>(fileContents);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}