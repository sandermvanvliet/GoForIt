using System.Collections.Generic;
using GoForIt.Controllers;

namespace GoForIt.Models
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }
}