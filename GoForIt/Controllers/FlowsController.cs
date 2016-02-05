using System;
using System.Collections.Generic;
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

        [HttpPost]
        public JsonResult Add(FlowModel flow)
        {
            try
            {
                var flowsPath = Server.MapPath("~/App_Data/Flows.json");
                var fileContents = System.IO.File.ReadAllText(flowsPath);

                var data = JsonConvert.DeserializeObject<List<FlowModel>>(fileContents);

                data.Add(flow);

                System.IO.File.WriteAllText(flowsPath, JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0)]
        public JsonResult List()
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Flows.json"));

            var data = JsonConvert.DeserializeObject<FlowModel[]>(fileContents);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}