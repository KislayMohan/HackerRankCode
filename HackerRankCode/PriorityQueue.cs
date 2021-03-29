using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class PriorityQueue<T>
    {
        public class Node
        {
            public int Priority { get; set; }
            public T Data { get; set; }
        }

        List<Node> queue = new List<Node>();
        int heapSize = -1;
        bool _isMinPriorityQueue = false;
        public int Count { get { return queue.Count; } }

        public PriorityQueue(bool isMinPriorityQueue = false)
        {
            _isMinPriorityQueue = isMinPriorityQueue;
        }

        private void Swap(int i, int j)
        {
            var temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }

        private int LeftChild(int pos)
        {
            return 2 * pos + 1;
        }

        private int RightChild(int pos)
        {
            return 2 * pos + 2;
        }

        private void MaxHeapify(int pos)
        {
            var leftChild = LeftChild(pos);
            var rightChild = RightChild(pos);

            var curr = pos;

            if (leftChild <= heapSize && queue[leftChild].Priority > queue[curr].Priority)
            {
                curr = leftChild;
            }
            if (rightChild <= heapSize && queue[rightChild].Priority > queue[curr].Priority)
            {
                curr = rightChild;
            }

            if (curr != pos)
            {
                Swap(curr, pos);
                MaxHeapify(curr);
            }
        }

        private void MinHeapify(int pos)
        {
            var leftChild = LeftChild(pos);
            var rightChild = RightChild(pos);

            var curr = pos;

            if (leftChild <= heapSize && queue[leftChild].Priority < queue[curr].Priority)
            {
                curr = leftChild;
            }
            if (rightChild <= heapSize && queue[rightChild].Priority < queue[curr].Priority)
            {
                curr = rightChild;
            }
            
            if (curr != pos)
            {
                Swap(curr, pos);
                MinHeapify(curr);
            }
        }

        private void BuildMaxHeap(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        private void BuildMinHeap(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        public void Enqueue(T data, int priority)
        {
            var node = new Node { Data = data, Priority = priority };
            queue.Add(node);
            heapSize++;
            if (_isMinPriorityQueue)
            {
                BuildMinHeap(heapSize);
            }
            else
            {
                BuildMaxHeap(heapSize);
            }
        }

        public T Dequeue()
        {
            if (heapSize >= 0)
            {
                var returnData = queue[0].Data;
                queue[0] = queue[heapSize];
                queue.RemoveAt(heapSize);
                heapSize--;
                if (_isMinPriorityQueue)
                {
                    MinHeapify(heapSize);
                }
                else
                {
                    MaxHeapify(heapSize);
                }
                return returnData;
            }
            else
            {
                throw new Exception("Queue is Empty");
            }
        }
    }
}
