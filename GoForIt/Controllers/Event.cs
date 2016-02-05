using System;
using System.Collections.Generic;
using GoForIt.Models;

namespace GoForIt.Controllers
{
    public class Event
    {
        public string Application { get; set; }
        public DateTime Timestamp { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }
}