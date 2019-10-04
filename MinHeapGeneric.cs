using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataStuctureLab
{

    // comparator class helps to compare the node 
    // on the basis of one of its attribute. 
    // Here we will be compared 
    // on the basis of data values of the nodes. 
    public class MyComparator<T> : IComparer<T> where T:IData
    {
        public int Compare(T x, T y)
        {
            return x.Data - y.Data;
        }
    }
    public class MinHeapGeneric<T> where T: IData
    {
        public static void Run()
        {
            Console.WriteLine("Min Heap - complete logic");

            MinHeap minHeap = new MinHeap(5);
            minHeap.Insert(3);
            minHeap.Insert(1);
            minHeap.Insert(10);
            minHeap.Insert(0);
            minHeap.Insert(12);
            minHeap.Print();

            var min = minHeap.ExtractMin();
            Console.WriteLine(min.Data);
            minHeap.Insert(13);
            minHeap.Print();

            min = minHeap.ExtractMin();
            Console.WriteLine(min.Data);
            minHeap.Print();
        }

        HeapNode<T>[] minHeap;
        int position;

        public MinHeapGeneric(int size)
        {
            this.minHeap = new HeapNode<T>[size];
            this.position = -1;
        }

        public void Insert(T data)
        {
            if (this.position < 0)
            {
                this.minHeap[++this.position] = new HeapNode<T>(data);
            }
            else
            {
                this.minHeap[++this.position] = new HeapNode<T>(data);
                this.BubbleUp();
            }
        }

        public void BubbleUp()
        {
            var pos = this.position;
            var parent = (pos - 1) / 2;
            while (pos > 0 && (new MyComparator<HeapNode<T>>().Compare(this.minHeap[parent], this.minHeap[pos])) > 0)
            {
                //swap
                HeapNode node = this.minHeap[parent];
                this.minHeap[parent] = this.minHeap[pos];
                this.minHeap[pos] = node;
                pos = parent;
                parent = (pos - 1) / 2;
            }
        }

        private void Swap(int a, int b)
        {
            //  System.out.println("swappinh" + mH[a] + " and " + mH[b]);
            HeapNode temp = this.minHeap[a];
            this.minHeap[a] = this.minHeap[b];
            this.minHeap[b] = temp;
        }

        private void SinkDown(int k)
        {
            int smallest = k;
            var left = (2 * k) + 1;
            var right = (2 * k) + 2;
            if (((left <= this.position) && (this.minHeap[smallest].Data > this.minHeap[left].Data)))
            {
                //left child
                smallest = left;
            }

            if (((right <= this.position) && (this.minHeap[smallest].Data > this.minHeap[right].Data)))
            {
                //right child
                smallest = right;
            }

            if ((smallest != k))
            {
                //  if any if the child is small, swap
                this.Swap(k, smallest);
                this.SinkDown(smallest);
                //  call recursively
            }
        }
        public HeapNode ExtractMin()
        {
            //return minHeap[0];
            var min = minHeap[0];
            if (this.position >= 0)
            {
                minHeap[0] = minHeap[position];
                minHeap[position] = null;
                position--;
            }

            this.SinkDown(0);

            return min;
        }

        public int Size => this.position + 1;

        public void Print(bool includeListNumber = false)
        {
            for (int i = 0; i <= this.position; i++)
            {
                if (includeListNumber)
                    Console.Write("[{0},{1}] ", this.minHeap[i].Data, this.minHeap[i].ListNumber);
                else
                    Console.Write("[{0}] ", this.minHeap[i].Data);
            }
            Console.WriteLine();
        }
    }

    public interface IData
    {
        int Data { get; set; }
    }
    public class HeapNode<T> where T : IData
    {
        public T Data { get; set; }
        public HeapNode(T data)
        {
            this.Data = data;
        }
    }
}
