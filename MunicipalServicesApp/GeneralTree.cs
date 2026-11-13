using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public class GeneralTreeNode
        {
            public string Label { get; private set; }
            public ServiceRequest Request { get; private set; }
            public GeneralTreeNode Parent { get; private set; }
            public List<GeneralTreeNode> Children { get; private set; }

            public bool IsRequest
            {
                get { return Request != null; }
            }

            public GeneralTreeNode(string label)
            {
                Label = label;
                Request = null;
                Children = new List<GeneralTreeNode>();
            }

            public GeneralTreeNode(ServiceRequest request)
            {
                Label = request.Id + " - " + request.Title;
                Request = request;
                Children = new List<GeneralTreeNode>();
            }

            public void SetParent(GeneralTreeNode parent)
            {
                Parent = parent;
            }

            public void AddChild(GeneralTreeNode child)
            {
                child.SetParent(this);
                Children.Add(child);
            }
        }

        // BASIC TREE: Root -> Category -> Service Requests
        public class GeneralTree
        {
            public GeneralTreeNode Root { get; private set; }
            public int RequestCount { get; private set; }

            public GeneralTree()
            {
                Root = new GeneralTreeNode("Municipal Services");
                RequestCount = 0;
            }

            public int CategoryCount
            {
                get { return Root.Children.Count; }
            }

            public void AddRequest(ServiceRequest request)
            {
                if (request == null)
                {
                    return;
                }

                GeneralTreeNode categoryNode = FindCategory(request.Category);

                if (categoryNode == null)
                {
                    categoryNode = new GeneralTreeNode(request.Category);
                    InsertCategoryAlphabetically(categoryNode);
                }

                categoryNode.AddChild(new GeneralTreeNode(request));
                RequestCount++;
            }

            public GeneralTreeNode FindCategory(string category)
            {
                foreach (GeneralTreeNode node in Root.Children)
                {
                    if (string.Equals(node.Label, category, StringComparison.OrdinalIgnoreCase))
                    {
                        return node;
                    }
                }
                return null;
            }

            public List<ServiceRequest> GetRequestsByCategory(string category)
            {
                List<ServiceRequest> results = new List<ServiceRequest>();
                GeneralTreeNode categoryNode = FindCategory(category);

                if (categoryNode == null)
                {
                    return results;
                }

                foreach (GeneralTreeNode child in categoryNode.Children)
                {
                    results.Add(child.Request);
                }
                return results;
            }

            public List<string> GetCategoryNames()
            {
                List<string> names = new List<string>();
                foreach (GeneralTreeNode node in Root.Children)
                {
                    names.Add(node.Label);
                }
                return names;
            }

            // Number of levels (root only = 1, root + categories + requests = 3)
            public int GetHeight()
            {
                return CalculateHeight(Root);
            }

            private int CalculateHeight(GeneralTreeNode node)
            {
                int tallestChild = 0;
                foreach (GeneralTreeNode child in node.Children)
                {
                    int childHeight = CalculateHeight(child);
                    if (childHeight > tallestChild)
                    {
                        tallestChild = childHeight;
                    }
                }
                return 1 + tallestChild;
            }

            public List<string> TraversePreOrder()
            {
                List<string> lines = new List<string>();
                PreOrder(Root, 0, lines);
                return lines;
            }

            private void PreOrder(GeneralTreeNode node, int depth, List<string> lines)
            {
                lines.Add(new string(' ', depth * 3) + node.Label);
                foreach (GeneralTreeNode child in node.Children)
                {
                    PreOrder(child, depth + 1, lines);
                }
            }

            private void InsertCategoryAlphabetically(GeneralTreeNode categoryNode)
            {
                int index = 0;
                while (index < Root.Children.Count &&
                       string.Compare(Root.Children[index].Label, categoryNode.Label,
                                      StringComparison.OrdinalIgnoreCase) < 0)
                {
                    index++;
                }

                categoryNode.SetParent(Root);
                Root.Children.Insert(index, categoryNode);
            }
        }
    }