using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{

        // MIN-HEAP: a complete binary tree stored in a list where every parent is
        // "smaller" than its children, so the smallest item is always at index 0.
        // Parent of i = (i-1)/2, children of i = 2i+1 and 2i+2.
        public class MinHeap<T>
        {
            private List<T> items = new List<T>();
            private Comparison<T> comparison;

            public MinHeap(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Count
            {
                get { return items.Count; }
            }

            public void Insert(T item)
            {
                items.Add(item);
                SiftUp(items.Count - 1);
            }

            public T Peek()
            {
                if (items.Count == 0)
                {
                    throw new InvalidOperationException("The heap is empty.");
                }
                return items[0];
            }

            public T ExtractMin()
            {
                if (items.Count == 0)
                {
                    throw new InvalidOperationException("The heap is empty.");
                }

                T smallest = items[0];
                int lastIndex = items.Count - 1;
                items[0] = items[lastIndex];
                items.RemoveAt(lastIndex);

                if (items.Count > 0)
                {
                    SiftDown(0);
                }
                return smallest;
            }

            // Builds a heap from existing items in O(n) (bottom-up heapify)
            public static MinHeap<T> BuildFrom(IEnumerable<T> source, Comparison<T> comparison)
            {
                MinHeap<T> heap = new MinHeap<T>(comparison);
                heap.items.AddRange(source);

                for (int i = heap.items.Count / 2 - 1; i >= 0; i--)
                {
                    heap.SiftDown(i);
                }
                return heap;
            }

            private void SiftUp(int index)
            {
                while (index > 0)
                {
                    int parent = (index - 1) / 2;
                    if (comparison(items[index], items[parent]) >= 0)
                    {
                        break;
                    }
                    Swap(index, parent);
                    index = parent;
                }
            }

            private void SiftDown(int index)
            {
                int count = items.Count;

                while (true)
                {
                    int left = 2 * index + 1;
                    int right = 2 * index + 2;
                    int smallest = index;

                    if (left < count && comparison(items[left], items[smallest]) < 0)
                    {
                        smallest = left;
                    }
                    if (right < count && comparison(items[right], items[smallest]) < 0)
                    {
                        smallest = right;
                    }
                    if (smallest == index)
                    {
                        break;
                    }

                    Swap(index, smallest);
                    index = smallest;
                }
            }

            private void Swap(int a, int b)
            {
                T temp = items[a];
                items[a] = items[b];
                items[b] = temp;
            }
        }
    }
