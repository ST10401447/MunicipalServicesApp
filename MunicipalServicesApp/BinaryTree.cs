using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        public class BinaryTreeNode
        {
            public ServiceRequest Request { get; private set; }
            public BinaryTreeNode Left { get; set; }
            public BinaryTreeNode Right { get; set; }

            public BinaryTreeNode(ServiceRequest request)
            {
                Request = request;
            }
        }

        // BINARY TREE: every node has at most two children. New requests are placed
        // in the first free spot reading left to right, level by level.
        public class BinaryTree
        {
            public BinaryTreeNode Root { get; private set; }
            public int Count { get; private set; }

            public void Insert(ServiceRequest request)
            {
                if (request == null)
                {
                    return;
                }

                BinaryTreeNode newNode = new BinaryTreeNode(request);
                Count++;

                if (Root == null)
                {
                    Root = newNode;
                    return;
                }

                Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(Root);

                while (queue.Count > 0)
                {
                    BinaryTreeNode current = queue.Dequeue();

                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        return;
                    }
                    queue.Enqueue(current.Left);

                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        return;
                    }
                    queue.Enqueue(current.Right);
                }
            }

            public List<ServiceRequest> LevelOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                if (Root == null)
                {
                    return result;
                }

                Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(Root);

                while (queue.Count > 0)
                {
                    BinaryTreeNode node = queue.Dequeue();
                    result.Add(node.Request);
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
                return result;
            }

            public List<ServiceRequest> PreOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                PreOrderVisit(Root, result);
                return result;
            }

            public List<ServiceRequest> InOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                InOrderVisit(Root, result);
                return result;
            }

            public List<ServiceRequest> PostOrder()
            {
                List<ServiceRequest> result = new List<ServiceRequest>();
                PostOrderVisit(Root, result);
                return result;
            }

            // Number of levels (empty = 0, single node = 1)
            public int GetHeight()
            {
                return Height(Root);
            }

            private int Height(BinaryTreeNode node)
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

            private void PreOrderVisit(BinaryTreeNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                result.Add(node.Request);
                PreOrderVisit(node.Left, result);
                PreOrderVisit(node.Right, result);
            }

            private void InOrderVisit(BinaryTreeNode node, List<ServiceRequest> result)
            {
                if (node == null)
                {
                    return;
                }
                InOrderVisit(node.Left, result);
                result.Add(node.Request);
                InOrderVisit(node.Right, result);
            }

            private void PostOrderVisit(BinaryTreeNode node, List<ServiceRequest> result)
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