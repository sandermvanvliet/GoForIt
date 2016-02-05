using System.Collections.Generic;
using GoForIt.Models;

namespace GoForIt.Controllers
{
    public class EventAction
    {
        public string Name { get; set; }
        public string Application { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }
}