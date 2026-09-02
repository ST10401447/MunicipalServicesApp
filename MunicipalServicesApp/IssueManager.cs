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

        public static void AddIssue(Issue issue)
        {
            Issues.Add(issue);
        }
    }
}
