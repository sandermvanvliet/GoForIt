using System.Collections.Generic;
using System.Web.Mvc;
using GoForIt.Models;

namespace GoForIt.Controllers
{
    public class EventsController : Controller
    {
        public JsonResult List()
        {
            var data = new[]
            {
                new EventViewModel
                {
                    Name = "File received",
                    Parameters = new List<ParameterModel>
                    {
                        new ParameterModel { Name = "Path", Description = "When received in" }
                    }
                },
                new EventViewModel
                {
                    Name = "RAM run completed",
                    Parameters = new List<ParameterModel>()
                },
                new EventViewModel
                {
                    Name = "Mail received",
                    Parameters = new List<ParameterModel>
                    {
                        new ParameterModel { Name = "From", Description = "Name of sender" }
                    }
                }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}