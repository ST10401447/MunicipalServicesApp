using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public enum RequestStatus
        {
            Submitted = 0,
            UnderReview = 1,
            InProgress = 2,
            Resolved = 3,
            Closed = 4
        }

        public class ServiceRequest
        {
            public int Number { get; private set; }

            public string Id
            {
                get { return "SR-" + Number.ToString(); }
            }

            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string Location { get; set; }

            // 1 = most urgent, 5 = least urgent
            public int Priority { get; set; }

            // Approximate map position in km (used by the graph to measure distance)
            public double X { get; set; }
            public double Y { get; set; }

            public RequestStatus Status { get; private set; }
            public DateTime DateSubmitted { get; private set; }
            public DateTime LastUpdated { get; private set; }
            public List<string> History { get; private set; }

            public ServiceRequest(int number, string title, string description,
                                  string category, string location, int priority)
                : this(number, title, description, category, location, priority, DateTime.Now)
            {
            }

            public ServiceRequest(int number, string title, string description,
                                  string category, string location, int priority,
                                  DateTime dateSubmitted)
            {
                Number = number;
                Title = title;
                Description = description;
                Category = category;
                Location = location;
                Priority = priority;
                Status = RequestStatus.Submitted;
                DateSubmitted = dateSubmitted;
                LastUpdated = dateSubmitted;
                History = new List<string>();
                History.Add(dateSubmitted.ToString("yyyy-MM-dd HH:mm") + "  Request submitted");
            }

            public void UpdateStatus(RequestStatus newStatus)
            {
                if (newStatus == Status)
                {
                    return;
                }

                Status = newStatus;
                LastUpdated = DateTime.Now;
                History.Add(LastUpdated.ToString("yyyy-MM-dd HH:mm") + "  Status changed to " + GetStatusText(newStatus));
            }

            public static string GetStatusText(RequestStatus status)
            {
                if (status == RequestStatus.UnderReview)
                {
                    return "Under Review";
                }
                if (status == RequestStatus.InProgress)
                {
                    return "In Progress";
                }
                return status.ToString();
            }

            public string StatusText
            {
                get { return GetStatusText(Status); }
            }

            public bool IsOpen
            {
                get { return Status != RequestStatus.Resolved && Status != RequestStatus.Closed; }
            }

            public string PriorityText
            {
                get
                {
                    switch (Priority)
                    {
                        case 1: return "1 - Critical";
                        case 2: return "2 - High";
                        case 3: return "3 - Medium";
                        case 4: return "4 - Low";
                        default: return "5 - Minor";
                    }
                }
            }

            public int ProgressPercent
            {
                get
                {
                    switch (Status)
                    {
                        case RequestStatus.Submitted: return 20;
                        case RequestStatus.UnderReview: return 40;
                        case RequestStatus.InProgress: return 70;
                        case RequestStatus.Resolved: return 90;
                        default: return 100;
                    }
                }
            }

            public override string ToString()
            {
                return Id + "  |  " + Title + "  |  " + StatusText;
            }
        }
    }