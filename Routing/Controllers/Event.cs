using System;
using System.Collections.Generic;

namespace Routing.Controllers
{
    public class Event
    {
        public string Application { get; set; }
        public DateTime Timestamp { get; set; }
        public List<string> Parameters { get; set; }
    }
}