using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        // Central store for all reported issues - a List<Issue> is the required data structure
        public static class IssueManager
        {
            public static List<Issue> Issues = new List<Issue>();

            // ADDED: the ID of the service request created for the most recent issue
            public static string LastRequestId = "";

            // CHANGED: now returns the matching service request
            public static ServiceRequest AddIssue(Issue issue)
            {
                Issues.Add(issue);

                // ADDED: every reported issue also becomes a trackable service request
                ServiceRequest request = ServiceRequestManager.CreateFromIssue(issue);
                LastRequestId = request.Id;
                return request;
            }
        }
    }
