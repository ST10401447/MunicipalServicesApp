using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public class AvlNode
        {
            public ServiceRequest Request { get; private set; }
            public AvlNode Left { get; set; }
            public AvlNode Right { get; set; }
            public int Height { get; set; }

            public AvlNode(ServiceRequest request)
            {
                Request = request;
                Height = 1;
            }
        }

        // AVL TREE: a binary search tree that rebalances itself with rotations so the
        // heights of the two subtrees of any node never differ by more than 1.
        // This is the main index used to look requests up by their unique ID.
        public class AvlTree
        {
            public AvlNode Root { get; private set; }
            public int Count { get; private set; }
            public int RotationCount { get; private set; }

            public void Insert(ServiceRequest request)
            {
                if (request == null)
                {
                    return;
                }
                Root = InsertNode(Root, request);
            }

            private AvlNode InsertNode(AvlNode node, ServiceRequest request)
            {
                if (node == null)
                {
                    Count++;
                    return new AvlNode(request);
                }

                if (request.Number < node.Request.Number)
                {
                    node.Left = InsertNode(node.Left, request);
                }
                else if (request.Number > node.Request.Number)
                {
                    node.Right = InsertNode(node.Right, request);
                }
                else
                {
                    return node;
                }

                UpdateHeight(node);
                int balance = GetBalance(node);

                // Left-Left
                if (balance > 1 && request.Number < node.Left.Request.Number)
                {
                    return RotateRight(node);
                }
                // Right-Right
                if (balance < -1 && request.Number > node.Right.Request.Number)
                {
                    return RotateLeft(node);
                }
                // Left-Right
                if (balance > 1 && request.Number > node.Left.Request.Number)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }
                // Right-Left
                if (balance < -1 && request.Number < node.Right.Request.Number)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }

            public ServiceRequest Search(int number, out int steps)
            {
                steps = 0;
                AvlNode current = Root;

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

            // Sorted by request number
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

            public int GetHeight()
            {
                return HeightOf(Root);
            }

            public bool IsBalanced()
            {
                return CheckBalanced(Root);
            }

            private bool CheckBalanced(AvlNode node)
            {
                if (node == null)
                {
                    return true;
                }
                int balance = GetBalance(node);
                if (balance > 1 || balance < -1)
                {
                    return false;
                }
                return CheckBalanced(node.Left) && CheckBalanced(node.Right);
            }

            private int HeightOf(AvlNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return node.Height;
            }

            private void UpdateHeight(AvlNode node)
            {
                node.Height = 1 + Math.Max(HeightOf(node.Left), HeightOf(node.Right));
            }

            private int GetBalance(AvlNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return HeightOf(node.Left) - HeightOf(node.Right);
            }

            private AvlNode RotateRight(AvlNode y)
            {
                AvlNode x = y.Left;
                AvlNode middle = x.Right;

                x.Right = y;
                y.Left = middle;

                UpdateHeight(y);
                UpdateHeight(x);
                RotationCount++;
                return x;
            }

            private AvlNode RotateLeft(AvlNode x)
            {
                AvlNode y = x.Right;
                AvlNode middle = y.Left;

                y.Left = x;
                x.Right = middle;

                UpdateHeight(x);
                UpdateHeight(y);
                RotationCount++;
                return y;
            }

            private void InOrderVisit(AvlNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                InOrderVisit(node.Left, result);
                result.Add(node.Request);
                InOrderVisit(node.Right, result);
            }

            private void PreOrderVisit(AvlNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                result.Add(node.Request);
                PreOrderVisit(node.Left, result);
                PreOrderVisit(node.Right, result);
            }
        }
    }
