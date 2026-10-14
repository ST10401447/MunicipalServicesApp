using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

    // One event (for example a market or a clean-up day)
    public class EventItem
    {
        public int Id;
        public string Title = "";
        public string Category = "";
        public DateTime Date;
        public string Location = "";
        public string Description = "";

        // This text is shown in the "Recently viewed" list
        public override string ToString()
        {
            return Date.ToString("ddd d MMM") + " - " + Title;
        }
    }

    // One announcement. Priority: 1 = urgent, 2 = important, 3 = notice
    public class Announcement
    {
        public string Title = "";
        public string Message = "";
        public int Priority = 3;
        public int Order = 0;

        public string PriorityLabel()
        {
            if (Priority == 1) return "URGENT";
            if (Priority == 2) return "IMPORTANT";
            return "NOTICE";
        }
    }

    // A recommended event together with the reason it was recommended
    public class Recommendation
    {
        public EventItem Event = new EventItem();
        public int Score = 0;
        public string Reason = "";
     
      public override string ToString()
        {
            return Event.Title + " - " + Reason;
        }

    }
}
