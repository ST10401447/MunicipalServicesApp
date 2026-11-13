using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public static class ServiceRequestManager
        {
            private static List<ServiceRequest> allRequests = new List<ServiceRequest>();
            private static GeneralTree categoryTree = new GeneralTree();
            private static BinaryTree submissionTree = new BinaryTree();
            private static BinarySearchTree bst = new BinarySearchTree();
            private static AvlTree avl = new AvlTree();
            private static RedBlackTree timeline = new RedBlackTree();
            private static RequestGraph graph = new RequestGraph();
            private static int nextNumber = 1001;

            // Approximate map positions (km from the city centre) used for graph distances
            private static readonly string[] AreaNames =
            {
            "Johannesburg CBD", "Braamfontein", "Parktown", "Melville", "Rosebank",
            "Sandton", "Rivonia", "Alexandra", "Bryanston", "Randburg",
            "Fourways", "Midrand", "Roodepoort", "Soweto"
        };
            private static readonly double[] AreaX = { 0, 0, 2, -3, 4, 9, 8, 10, 7, -2, 3, 14, -17, -12 };
            private static readonly double[] AreaY = { 0, 2, 4, 3, 7, 12, 14, 10, 16, 13, 22, 24, 5, -12 };

            static ServiceRequestManager()
            {
                SeedSampleData();
            }

            public static int Count
            {
                get { return allRequests.Count; }
            }

            public static RequestGraph Graph
            {
                get { return graph; }
            }

            // ---------- CREATING REQUESTS ----------

            public static ServiceRequest Submit(string title, string description, string category,
                                                string location, int priority)
            {
                return CreateAndRegister(title, description, category, location, priority, DateTime.Now);
            }

            // Called by IssueManager so every issue reported in Part 1 becomes a trackable request
            public static ServiceRequest CreateFromIssue(Issue issue)
            {
                string category = issue.Category;
                if (string.IsNullOrWhiteSpace(category))
                {
                    category = "General";
                }

                string location = issue.Location;
                if (string.IsNullOrWhiteSpace(location))
                {
                    location = "Unknown location";
                }

                string description = issue.Description;
                if (description == null)
                {
                    description = "";
                }

                string title = category + " issue at " + Shorten(location, 28);
                int priority = DerivePriority(category, description);

                return CreateAndRegister(title, description, category, location, priority, DateTime.Now);
            }

            private static ServiceRequest CreateAndRegister(string title, string description, string category,
                                                            string location, int priority, DateTime submitted)
            {
                ServiceRequest request = new ServiceRequest(nextNumber, title, description,
                                                            category, location, priority, submitted);
                nextNumber++;

                double x;
                double y;
                GetCoordinates(location, out x, out y);
                request.X = x;
                request.Y = y;

                allRequests.Add(request);
                categoryTree.AddRequest(request);
                submissionTree.Insert(request);
                bst.Insert(request);
                avl.Insert(request);
                timeline.Insert(request);
                graph.AddVertex(request);

                return request;
            }

            public static void UpdateStatus(ServiceRequest request, RequestStatus newStatus)
            {
                if (request != null)
                {
                    request.UpdateStatus(newStatus);
                }
            }

            // ---------- READING / SEARCHING ----------

            public static List<ServiceRequest> GetAll()
            {
                return avl.InOrder();
            }

            public static List<ServiceRequest> GetByCategory(string category)
            {
                return categoryTree.GetRequestsByCategory(category);
            }

            public static List<string> GetCategoryNames()
            {
                return categoryTree.GetCategoryNames();
            }

            // Unique-ID lookup through the AVL tree. Accepts "SR-1003", "sr1003" or "1003".
            public static ServiceRequest FindById(string text, out int steps)
            {
                steps = 0;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return null;
                }

                string cleaned = text.Trim().ToUpperInvariant();
                if (cleaned.StartsWith("SR"))
                {
                    cleaned = cleaned.Substring(2);
                }
                cleaned = cleaned.Trim('-', ' ', '#');

                int number;
                if (!int.TryParse(cleaned, out number))
                {
                    return null;
                }

                return avl.Search(number, out steps);
            }

            // ---------- ORDERING ----------

            // Sorted by request number using the AVL in-order traversal
            public static List<ServiceRequest> OrderByNumber(List<ServiceRequest> subset)
            {
                HashSet<int> wanted = ToNumberSet(subset);
                List<ServiceRequest> result = new List<ServiceRequest>();

                foreach (ServiceRequest request in avl.InOrder())
                {
                    if (wanted.Contains(request.Number))
                    {
                        result.Add(request);
                    }
                }
                return result;
            }

            // Newest first using the red-black timeline
            public static List<ServiceRequest> OrderNewestFirst(List<ServiceRequest> subset)
            {
                HashSet<int> wanted = ToNumberSet(subset);
                List<ServiceRequest> result = new List<ServiceRequest>();

                foreach (ServiceRequest request in timeline.NewestFirst())
                {
                    if (wanted.Contains(request.Number))
                    {
                        result.Add(request);
                    }
                }
                return result;
            }

            // Most urgent first using heap sort (build heap, then extract the minimum repeatedly)
            public static List<ServiceRequest> OrderByUrgency(List<ServiceRequest> subset)
            {
                MinHeap<ServiceRequest> heap = MinHeap<ServiceRequest>.BuildFrom(subset, CompareUrgency);
                List<ServiceRequest> result = new List<ServiceRequest>();

                while (heap.Count > 0)
                {
                    result.Add(heap.ExtractMin());
                }
                return result;
            }

            // The most urgent requests that are still open (priority queue)
            public static List<ServiceRequest> GetMostUrgent(int count)
            {
                List<ServiceRequest> open = new List<ServiceRequest>();
                foreach (ServiceRequest request in allRequests)
                {
                    if (request.IsOpen)
                    {
                        open.Add(request);
                    }
                }

                MinHeap<ServiceRequest> heap = MinHeap<ServiceRequest>.BuildFrom(open, CompareUrgency);
                List<ServiceRequest> result = new List<ServiceRequest>();

                while (heap.Count > 0 && result.Count < count)
                {
                    result.Add(heap.ExtractMin());
                }
                return result;
            }

            private static int CompareUrgency(ServiceRequest a, ServiceRequest b)
            {
                int result = a.Priority.CompareTo(b.Priority);
                if (result != 0)
                {
                    return result;
                }
                result = a.DateSubmitted.CompareTo(b.DateSubmitted);
                if (result != 0)
                {
                    return result;
                }
                return a.Number.CompareTo(b.Number);
            }

            private static HashSet<int> ToNumberSet(List<ServiceRequest> subset)
            {
                HashSet<int> numbers = new HashSet<int>();
                foreach (ServiceRequest request in subset)
                {
                    numbers.Add(request.Number);
                }
                return numbers;
            }

            // ---------- INSIGHTS (shown on the Data Structure Insights tab) ----------

            public static string GetInsights()
            {
                StringBuilder sb = new StringBuilder();
                int n = allRequests.Count;
                int minimumLevels = 0;
                if (n > 0)
                {
                    minimumLevels = (int)Math.Ceiling(Math.Log(n + 1, 2));
                }

                sb.AppendLine("DATA STRUCTURE INSIGHTS");
                sb.AppendLine("=======================");
                sb.AppendLine("Total service requests: " + n);
                sb.AppendLine();

                sb.AppendLine("TREE HEIGHTS (number of levels)");
                sb.AppendLine("  Best possible for " + n + " items : " + minimumLevels);
                sb.AppendLine("  Binary search tree          : " + bst.GetHeight() + "   (not balanced - leans because IDs are sequential)");
                sb.AppendLine("  AVL tree                    : " + avl.GetHeight() + "   (balanced: " + avl.IsBalanced() + ", rotations done: " + avl.RotationCount + ")");
                sb.AppendLine("  Red-black tree (timeline)   : " + timeline.GetHeight() + "   (rules valid: " + timeline.IsValid() + ")");
                sb.AppendLine("  Binary tree (submission)    : " + submissionTree.GetHeight());
                sb.AppendLine("  Basic category tree         : " + categoryTree.GetHeight() + "   (root > category > request)");
                sb.AppendLine();

                sb.AppendLine("BASIC TREE - requests per category");
                foreach (string name in categoryTree.GetCategoryNames())
                {
                    sb.AppendLine("  " + name + " : " + categoryTree.GetRequestsByCategory(name).Count);
                }
                sb.AppendLine();

                sb.AppendLine("BINARY TREE - level-order (first 10)");
                sb.AppendLine("  " + JoinIds(submissionTree.LevelOrder(), 10));
                sb.AppendLine("BINARY SEARCH TREE - pre-order (first 10)");
                sb.AppendLine("  " + JoinIds(bst.PreOrder(), 10));
                sb.AppendLine("AVL TREE - pre-order (first 10)  [root is balanced near the middle]");
                sb.AppendLine("  " + JoinIds(avl.PreOrder(), 10));
                sb.AppendLine();

                DateTime weekAgo = DateTime.Now.AddDays(-7);
                List<ServiceRequest> lastWeek = timeline.GetRange(weekAgo, DateTime.Now);
                sb.AppendLine("RED-BLACK TREE - range query");
                sb.AppendLine("  Requests submitted in the last 7 days: " + lastWeek.Count);
                sb.AppendLine();

                sb.AppendLine("HEAP - most urgent open requests (top 5)");
                foreach (ServiceRequest request in GetMostUrgent(5))
                {
                    sb.AppendLine("  " + request.Id + "  priority " + request.Priority + "  " + request.Title);
                }
                sb.AppendLine();

                MstResult kruskal = graph.KruskalMst();
                sb.AppendLine("GRAPH");
                sb.AppendLine("  Vertices (requests)   : " + graph.VertexCount);
                sb.AppendLine("  Edges (relationships) : " + graph.EdgeCount);
                sb.AppendLine("  Connected groups      : " + graph.CountComponents());
                sb.AppendLine("  Minimum spanning tree : " + kruskal.Edges.Count + " links, total " + kruskal.TotalWeight.ToString("0.0") + " km");

                return sb.ToString();
            }

            private static string JoinIds(List<ServiceRequest> list, int max)
            {
                StringBuilder sb = new StringBuilder();
                int shown = 0;
                foreach (ServiceRequest request in list)
                {
                    if (shown >= max)
                    {
                        break;
                    }
                    if (shown > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(request.Id);
                    shown++;
                }
                return sb.ToString();
            }

            // ---------- HELPERS ----------

            private static string Shorten(string text, int maxLength)
            {
                text = text.Trim();
                if (text.Length <= maxLength)
                {
                    return text;
                }
                return text.Substring(0, maxLength - 3) + "...";
            }

            private static int DerivePriority(string category, string description)
            {
                string text = (category + " " + description).ToLowerInvariant();

                if (ContainsAny(text, "burst", "leak", "sewage", "sewer", "electric", "power", "fire", "gas", "danger", "exposed", "flood"))
                {
                    return 1;
                }
                if (ContainsAny(text, "road", "pothole", "traffic", "light", "water"))
                {
                    return 2;
                }
                if (ContainsAny(text, "waste", "refuse", "garbage", "dump", "sanitation", "bin"))
                {
                    return 3;
                }
                return 4;
            }

            private static bool ContainsAny(string text, params string[] words)
            {
                foreach (string word in words)
                {
                    if (text.Contains(word))
                    {
                        return true;
                    }
                }
                return false;
            }

            private static void GetCoordinates(string location, out double x, out double y)
            {
                for (int i = 0; i < AreaNames.Length; i++)
                {
                    if (location.IndexOf(AreaNames[i], StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        x = AreaX[i];
                        y = AreaY[i];
                        return;
                    }
                }

                // Unknown place: derive a stable position from the text so it still joins the graph
                int hash = 17;
                foreach (char c in location.ToLowerInvariant())
                {
                    hash = (hash * 31 + c) % 100003;
                }
                x = hash % 30;
                y = (hash / 30) % 30;
            }

            private static void Seed(string title, string description, string category, string location,
                                     int priority, int daysAgo, RequestStatus finalStatus)
            {
                DateTime submitted = DateTime.Now.AddDays(-daysAgo);
                ServiceRequest request = CreateAndRegister(title, description, category, location, priority, submitted);

                for (int step = 1; step <= (int)finalStatus; step++)
                {
                    request.UpdateStatus((RequestStatus)step);
                }
            }

            private static void SeedSampleData()
            {
                Seed("Burst water pipe", "Water flowing across the road", "Water & Sanitation", "Rivonia Road, Sandton", 1, 12, RequestStatus.InProgress);
                Seed("Large pothole", "Deep pothole damaging cars", "Roads", "Jan Smuts Avenue, Rosebank", 2, 11, RequestStatus.UnderReview);
                Seed("Streetlights not working", "Whole street dark at night", "Street Lighting", "Republic Road, Randburg", 3, 10, RequestStatus.Resolved);
                Seed("Overflowing refuse bins", "Bins not collected for two weeks", "Waste Management", "Vilakazi Street, Soweto", 3, 9, RequestStatus.Submitted);
                Seed("Power outage", "No electricity since Monday", "Electricity", "London Road, Alexandra", 1, 9, RequestStatus.InProgress);
                Seed("Blocked storm drain", "Water pooling after rain", "Water & Sanitation", "Chris Hani Road, Soweto", 2, 8, RequestStatus.UnderReview);
                Seed("Pothole near school", "Dangerous for learners crossing", "Roads", "Old Pretoria Road, Midrand", 2, 7, RequestStatus.Submitted);
                Seed("Illegal dumping", "Rubble dumped on vacant land", "Waste Management", "Ontdekkers Road, Roodepoort", 3, 6, RequestStatus.UnderReview);
                Seed("Faulty traffic light", "Robot stuck on red", "Roads", "Johannesburg CBD, Commissioner Street", 1, 6, RequestStatus.InProgress);
                Seed("Sewage leak", "Sewage running into the street", "Water & Sanitation", "2nd Avenue, Alexandra", 1, 5, RequestStatus.Submitted);
                Seed("Broken streetlight pole", "Pole leaning over the pavement", "Street Lighting", "West Street, Sandton", 2, 4, RequestStatus.Resolved);
                Seed("Missed refuse collection", "Collection skipped this week", "Waste Management", "Witkoppen Road, Fourways", 4, 3, RequestStatus.Submitted);
                Seed("Exposed electrical cable", "Live cable hanging low", "Electricity", "Bryanston Drive, Bryanston", 1, 3, RequestStatus.UnderReview);
                Seed("Water meter fault", "Meter showing wrong readings", "Water & Sanitation", "Hendrik Verwoerd Drive, Randburg", 4, 2, RequestStatus.Submitted);
                Seed("Faded road markings", "Lane lines no longer visible", "Roads", "Oxford Road, Rosebank", 4, 2, RequestStatus.Submitted);
                Seed("Park lights not working", "Park unsafe after dark", "Street Lighting", "7th Street, Melville", 3, 1, RequestStatus.Submitted);
            }
        }
    }