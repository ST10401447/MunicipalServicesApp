using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{


        public enum NodeColor
        {
            Red,
            Black
        }

        public class RbNode
        {
            public ServiceRequest Request { get; private set; }
            public RbNode Left { get; set; }
            public RbNode Right { get; set; }
            public RbNode Parent { get; set; }
            public NodeColor Color { get; set; }

            public RbNode(ServiceRequest request)
            {
                Request = request;
                Color = NodeColor.Red;
            }
        }

        // RED-BLACK TREE ordered by date submitted (then by number to break ties).
        // Colour rules keep it roughly balanced, so inserts and searches stay O(log n).
        public class RedBlackTree
        {
            private RbNode root;

            public int Count { get; private set; }

            private int Compare(ServiceRequest a, ServiceRequest b)
            {
                int result = a.DateSubmitted.CompareTo(b.DateSubmitted);
                if (result != 0)
                {
                    return result;
                }
                return a.Number.CompareTo(b.Number);
            }

            public void Insert(ServiceRequest request)
            {
                if (request == null)
                {
                    return;
                }

                RbNode newNode = new RbNode(request);
                RbNode parent = null;
                RbNode current = root;

                while (current != null)
                {
                    parent = current;
                    int comparison = Compare(request, current.Request);
                    if (comparison == 0)
                    {
                        return;
                    }
                    if (comparison < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                newNode.Parent = parent;

                if (parent == null)
                {
                    root = newNode;
                }
                else if (Compare(request, parent.Request) < 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }

                Count++;
                FixAfterInsert(newNode);
            }

            private void FixAfterInsert(RbNode node)
            {
                while (node != root && node.Parent.Color == NodeColor.Red)
                {
                    RbNode parent = node.Parent;
                    RbNode grandparent = parent.Parent;

                    if (parent == grandparent.Left)
                    {
                        RbNode uncle = grandparent.Right;

                        if (uncle != null && uncle.Color == NodeColor.Red)
                        {
                            parent.Color = NodeColor.Black;
                            uncle.Color = NodeColor.Black;
                            grandparent.Color = NodeColor.Red;
                            node = grandparent;
                        }
                        else
                        {
                            if (node == parent.Right)
                            {
                                node = parent;
                                RotateLeft(node);
                                parent = node.Parent;
                            }
                            parent.Color = NodeColor.Black;
                            grandparent.Color = NodeColor.Red;
                            RotateRight(grandparent);
                        }
                    }
                    else
                    {
                        RbNode uncle = grandparent.Left;

                        if (uncle != null && uncle.Color == NodeColor.Red)
                        {
                            parent.Color = NodeColor.Black;
                            uncle.Color = NodeColor.Black;
                            grandparent.Color = NodeColor.Red;
                            node = grandparent;
                        }
                        else
                        {
                            if (node == parent.Left)
                            {
                                node = parent;
                                RotateRight(node);
                                parent = node.Parent;
                            }
                            parent.Color = NodeColor.Black;
                            grandparent.Color = NodeColor.Red;
                            RotateLeft(grandparent);
                        }
                    }
                }

                root.Color = NodeColor.Black;
            }

            private void RotateLeft(RbNode x)
            {
                RbNode y = x.Right;
                x.Right = y.Left;

                if (y.Left != null)
                {
                    y.Left.Parent = x;
                }

                y.Parent = x.Parent;

                if (x.Parent == null)
                {
                    root = y;
                }
                else if (x == x.Parent.Left)
                {
                    x.Parent.Left = y;
                }
                else
                {
                    x.Parent.Right = y;
                }

                y.Left = x;
                x.Parent = y;
            }

            private void RotateRight(RbNode x)
            {
                RbNode y = x.Left;
                x.Left = y.Right;

                if (y.Right != null)
                {
                    y.Right.Parent = x;
                }

                y.Parent = x.Parent;

                if (x.Parent == null)
                {
                    root = y;
                }
                else if (x == x.Parent.Right)
                {
                    x.Parent.Right = y;
                }
                else
                {
                    x.Parent.Left = y;
                }

                y.Right = x;
                x.Parent = y;
            }

            // Oldest first
            public List<ServiceRequest> OldestFirst()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                InOrderVisit(root, result);
                return result;
            }

            // Newest first (reverse in-order)
            public List<ServiceRequest> NewestFirst()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                ReverseVisit(root, result);
                return result;
            }

            // All requests submitted between two dates (inclusive)
            public List<ServiceRequest> GetRange(DateTime start, DateTime end)
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                CollectRange(root, start, end, result);
                return result;
            }

            public int GetHeight()
            {
                return Height(root);
            }

            // Checks the red-black rules: black root, no red node with a red child,
            // and the same number of black nodes on every path.
            public bool IsValid()
            {
                if (root == null)
                {
                    return true;
                }
                if (root.Color != NodeColor.Black)
                {
                    return false;
                }
                return CheckBlackHeight(root) != -1;
            }

            private int CheckBlackHeight(RbNode node)
            {
                if (node == null)
                {
                    return 1;
                }

                if (node.Color == NodeColor.Red)
                {
                    bool leftRed = node.Left != null && node.Left.Color == NodeColor.Red;
                    bool rightRed = node.Right != null && node.Right.Color == NodeColor.Red;
                    if (leftRed || rightRed)
                    {
                        return -1;
                    }
                }

                int leftHeight = CheckBlackHeight(node.Left);
                int rightHeight = CheckBlackHeight(node.Right);

                if (leftHeight == -1 || rightHeight == -1 || leftHeight != rightHeight)
                {
                    return -1;
                }

                if (node.Color == NodeColor.Black)
                {
                    return leftHeight + 1;
                }
                return leftHeight;
            }

            private int Height(RbNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                int left = Height(node.Left);
                int right = Height(node.Right);
                if (left > right)
                {
                    return left + 1;
                }
                return right + 1;
            }

            private void InOrderVisit(RbNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                InOrderVisit(node.Left, result);
                result.Add(node.Request);
                InOrderVisit(node.Right, result);
            }

            private void ReverseVisit(RbNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                ReverseVisit(node.Right, result);
                result.Add(node.Request);
                ReverseVisit(node.Left, result);
            }

            private void CollectRange(RbNode node, DateTime start, DateTime end, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }

                DateTime date = node.Request.DateSubmitted;

                if (date >= start)
                {
                    CollectRange(node.Left, start, end, result);
                }
                if (date >= start && date <= end)
                {
                    result.Add(node.Request);
                }
                if (date <= end)
                {
                    CollectRange(node.Right, start, end, result);
                }
            }
        }
    }
