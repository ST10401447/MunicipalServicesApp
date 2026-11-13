using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
        public class BstNode
        {
            public ServiceRequest Request { get; private set; }
            public BstNode Left { get; set; }
            public BstNode Right { get; set; }

            public BstNode(ServiceRequest request)
            {
                Request = request;
            }
        }

        // BINARY SEARCH TREE keyed by request number.
        // Smaller numbers go left, larger numbers go right. It is NOT self-balancing,
        // so sequential IDs make it lean to one side (compare its height with the AVL tree).
        public class BinarySearchTree
        {
            public BstNode Root { get; private set; }
            public int Count { get; private set; }

            public bool Insert(ServiceRequest request)
            {
                if (request == null)
                {
                    return false;
                }

                BstNode newNode = new BstNode(request);

                if (Root == null)
                {
                    Root = newNode;
                    Count++;
                    return true;
                }

                BstNode current = Root;
                while (true)
                {
                    if (request.Number == current.Request.Number)
                    {
                        return false;
                    }

                    if (request.Number < current.Request.Number)
                    {
                        if (current.Left == null)
                        {
                            current.Left = newNode;
                            Count++;
                            return true;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = newNode;
                            Count++;
                            return true;
                        }
                        current = current.Right;
                    }
                }
            }

            // Searches by request number and reports how many nodes were compared
            public ServiceRequest Search(int number, out int steps)
            {
                steps = 0;
                BstNode current = Root;

                while (current != null)
                {
                    steps++;
                    if (number == current.Request.Number)
                    {
                        return current.Request;
                    }
                    if (number < current.Request.Number)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                return null;
            }

            public ServiceRequest FindMin()
            {
                if (Root == null)
                {
                    return null;
                }
                BstNode current = Root;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.Request;
            }

            public ServiceRequest FindMax()
            {
                if (Root == null)
                {
                    return null;
                }
                BstNode current = Root;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                return current.Request;
            }

            // In-order gives the requests sorted by number
            public List<ServiceRequest> InOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                InOrderVisit(Root, result);
                return result;
            }

            public List<ServiceRequest> PreOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                PreOrderVisit(Root, result);
                return result;
            }

            public List<ServiceRequest> PostOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                PostOrderVisit(Root, result);
                return result;
            }

            public int GetHeight()
            {
                return Height(Root);
            }

            private int Height(BstNode node)
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

            private void InOrderVisit(BstNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                InOrderVisit(node.Left, result);
                result.Add(node.Request);
                InOrderVisit(node.Right, result);
            }

            private void PreOrderVisit(BstNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                result.Add(node.Request);
                PreOrderVisit(node.Left, result);
                PreOrderVisit(node.Right, result);
            }

            private void PostOrderVisit(BstNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                PostOrderVisit(node.Left, result);
                PostOrderVisit(node.Right, result);
                result.Add(node.Request);
            }
        }
    }