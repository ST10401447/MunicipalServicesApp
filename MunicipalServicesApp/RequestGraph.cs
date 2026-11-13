using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public class GraphEdge
        {
            public ServiceRequest Source { get; private set; }
            public ServiceRequest Target { get; private set; }
            public double Weight { get; private set; }

            public GraphEdge(ServiceRequest source, ServiceRequest target, double weight)
            {
                Source = source;
                Target = target;
                Weight = weight;
            }
        }

        public class TraversalStep
        {
            public ServiceRequest Request { get; private set; }
            public int Depth { get; private set; }

            public TraversalStep(ServiceRequest request, int depth)
            {
                Request = request;
                Depth = depth;
            }
        }

        public class MstResult
        {
            public List<GraphEdge> Edges { get; private set; }
            public double TotalWeight { get; set; }
            public int Components { get; set; }

            public MstResult()
            {
                Edges = new List<GraphEdge>();
            }
        }

        // UNDIRECTED WEIGHTED GRAPH stored as an adjacency list.
        public class RequestGraph
        {
            public const double RelatedDistanceKm = 5.0;

            private Dictionary<int, ServiceRequest> vertices = new Dictionary<int, ServiceRequest>();
            private Dictionary<int, List<GraphEdge>> adjacency = new Dictionary<int, List<GraphEdge>>();

            public int VertexCount
            {
                get { return vertices.Count; }
            }

            public int EdgeCount { get; private set; }

            public void AddVertex(ServiceRequest request)
            {
                if (request == null || vertices.ContainsKey(request.Number))
                {
                    return;
                }

                List<ServiceRequest> existing = new List<ServiceRequest>(vertices.Values);

                vertices[request.Number] = request;
                adjacency[request.Number] = new List<GraphEdge>();

                foreach (ServiceRequest other in existing)
                {
                    if (AreRelated(request, other))
                    {
                        AddEdge(request, other);
                    }
                }
            }

            public static double Distance(ServiceRequest a, ServiceRequest b)
            {
                double dx = a.X - b.X;
                double dy = a.Y - b.Y;
                return Math.Round(Math.Sqrt(dx * dx + dy * dy), 1);
            }

            public static bool AreRelated(ServiceRequest a, ServiceRequest b)
            {
                if (string.Equals(a.Category, b.Category, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return Distance(a, b) <= RelatedDistanceKm;
            }

            private void AddEdge(ServiceRequest a, ServiceRequest b)
            {
                double weight = Distance(a, b);
                adjacency[a.Number].Add(new GraphEdge(a, b, weight));
                adjacency[b.Number].Add(new GraphEdge(b, a, weight));
                EdgeCount++;
            }

            private static int CompareEdges(GraphEdge a, GraphEdge b)
            {
                int result = a.Weight.CompareTo(b.Weight);
                if (result != 0)
                {
                    return result;
                }
                result = a.Source.Number.CompareTo(b.Source.Number);
                if (result != 0)
                {
                    return result;
                }
                return a.Target.Number.CompareTo(b.Target.Number);
            }

            // Neighbours sorted by distance (closest first)
            public List<GraphEdge> GetNeighbours(int number)
            {
                List<GraphEdge> edges = new List<GraphEdge>();
                if (adjacency.ContainsKey(number))
                {
                    edges.AddRange(adjacency[number]);
                    edges.Sort(CompareEdges);
                }
                return edges;
            }

            // ---------- GRAPH TRAVERSAL ----------

            // Breadth-first: visits the closest links first, level by level (uses a queue)
            public List<TraversalStep> BreadthFirst(int startNumber)
            {
                List<TraversalStep> order = new List<TraversalStep>();
                if (!vertices.ContainsKey(startNumber))
                {
                    return order;
                }

                HashSet<int> visited = new HashSet<int>();
                Queue<TraversalStep> queue = new Queue<TraversalStep>();

                visited.Add(startNumber);
                queue.Enqueue(new TraversalStep(vertices[startNumber], 0));

                while (queue.Count > 0)
                {
                    TraversalStep current = queue.Dequeue();
                    order.Add(current);

                    foreach (GraphEdge edge in GetNeighbours(current.Request.Number))
                    {
                        if (visited.Add(edge.Target.Number))
                        {
                            queue.Enqueue(new TraversalStep(edge.Target, current.Depth + 1));
                        }
                    }
                }
                return order;
            }

            // Depth-first: follows one chain of links as far as it goes before backtracking
            public List<TraversalStep> DepthFirst(int startNumber)
            {
                List<TraversalStep> order = new List<TraversalStep>();
                if (!vertices.ContainsKey(startNumber))
                {
                    return order;
                }

                HashSet<int> visited = new HashSet<int>();
                Visit(vertices[startNumber], 0, visited, order);
                return order;
            }

            private void Visit(ServiceRequest request, int depth, HashSet<int> visited, List<TraversalStep> order)
            {
                visited.Add(request.Number);
                order.Add(new TraversalStep(request, depth));

                foreach (GraphEdge edge in GetNeighbours(request.Number))
                {
                    if (!visited.Contains(edge.Target.Number))
                    {
                        Visit(edge.Target, depth + 1, visited, order);
                    }
                }
            }

            public int CountComponents()
            {
                HashSet<int> visited = new HashSet<int>();
                int components = 0;

                foreach (int number in vertices.Keys)
                {
                    if (visited.Contains(number))
                    {
                        continue;
                    }

                    components++;
                    foreach (TraversalStep step in BreadthFirst(number))
                    {
                        visited.Add(step.Request.Number);
                    }
                }
                return components;
            }

            // ---------- MINIMUM SPANNING TREE ----------

            // Kruskal: sort all edges by weight, add each edge that does not form a cycle
            public MstResult KruskalMst()
            {
                MstResult result = new MstResult();
                List<GraphEdge> edges = new List<GraphEdge>();

                foreach (KeyValuePair<int, List<GraphEdge>> pair in adjacency)
                {
                    foreach (GraphEdge edge in pair.Value)
                    {
                        if (edge.Source.Number < edge.Target.Number)
                        {
                            edges.Add(edge);
                        }
                    }
                }

                edges.Sort(CompareEdges);

                Dictionary<int, int> parent = new Dictionary<int, int>();
                foreach (int number in vertices.Keys)
                {
                    parent[number] = number;
                }

                foreach (GraphEdge edge in edges)
                {
                    int rootA = Find(parent, edge.Source.Number);
                    int rootB = Find(parent, edge.Target.Number);

                    if (rootA != rootB)
                    {
                        parent[rootA] = rootB;
                        result.Edges.Add(edge);
                        result.TotalWeight += edge.Weight;
                    }
                }

                result.TotalWeight = Math.Round(result.TotalWeight, 1);
                result.Components = vertices.Count - result.Edges.Count;
                return result;
            }

            private static int Find(Dictionary<int, int> parent, int number)
            {
                while (parent[number] != number)
                {
                    parent[number] = parent[parent[number]];
                    number = parent[number];
                }
                return number;
            }

            // Prim: grow the tree from a start request, always taking the cheapest
            // edge that reaches a new request (uses the min-heap)
            public MstResult PrimMst()
            {
                MstResult result = new MstResult();
                HashSet<int> visited = new HashSet<int>();

                List<int> numbers = new List<int>(vertices.Keys);
                numbers.Sort();

                foreach (int start in numbers)
                {
                    if (visited.Contains(start))
                    {
                        continue;
                    }

                    result.Components++;
                    visited.Add(start);

                    MinHeap<GraphEdge> heap = new MinHeap<GraphEdge>(CompareEdges);
                    foreach (GraphEdge edge in adjacency[start])
                    {
                        heap.Insert(edge);
                    }

                    while (heap.Count > 0)
                    {
                        GraphEdge cheapest = heap.ExtractMin();

                        if (visited.Contains(cheapest.Target.Number))
                        {
                            continue;
                        }

                        visited.Add(cheapest.Target.Number);
                        result.Edges.Add(cheapest);
                        result.TotalWeight += cheapest.Weight;

                        foreach (GraphEdge next in adjacency[cheapest.Target.Number])
                        {
                            if (!visited.Contains(next.Target.Number))
                            {
                                heap.Insert(next);
                            }
                        }
                    }
                }

                result.TotalWeight = Math.Round(result.TotalWeight, 1);
                return result;
            }
        }
    }