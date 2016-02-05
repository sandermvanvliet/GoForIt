using GoForIt.Controllers;
using Microsoft.AspNet.SignalR;

namespace GoForIt
{
    public class EventLogHub : Hub
    {
        public void NewEvent(Event theEvent)
        {
            Clients.All.newEvent(theEvent);
        }
    }
}