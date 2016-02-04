using System.Collections.Generic;

namespace GoForIt.Models
{
    public class FlowModel
    {
        public string EventName { get; set; }
        public List<ParameterModel> EventParameters { get; set; }
        public string ActionName { get; set; }
        public List<ParameterModel> ActionParameters { get; set; }
    }
}