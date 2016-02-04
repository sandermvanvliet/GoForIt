using System.Collections.Generic;
using System.Web.Mvc;
using GoForIt.Models;

namespace GoForIt.Controllers
{
    public class ActionsController : Controller
    {
        public ActionResult List()
        {
            var data = new[]
            {
                new EventViewModel
                {
                    Name = "Send Chatr message",
                    Parameters = new List<ParameterModel>
                    {
                        new ParameterModel { Name = "Path", Description = "When received in" }
                    }
                },
                new EventViewModel
                {
                    Name = "Send e-mail",
                    Parameters = new List<ParameterModel>()
                },
                new EventViewModel
                {
                    Name = "Copy file",
                    Parameters = new List<ParameterModel>
                    {
                        new ParameterModel { Name = "From", Description = "Name of sender" }
                    }
                },
                new EventViewModel
                {
                    Name = "Start LQA assessment",
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