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
    public class MyComparator : IComparer<HeapNode<HuffmanNode>>
    {
        public int Compare(HeapNode<HuffmanNode> x, HeapNode<HuffmanNode> y)
        {
            return x.Data.data - y.Data.data;
        }
    }
    public class MinHeapGeneric
    {
        private static void Run()
        {
            ////Console.WriteLine("Min Heap - complete logic");

            ////MinHeapGeneric minHeap = new MinHeapGeneric(5);
            ////minHeap.Insert(3);
            ////minHeap.Insert(1);
            ////minHeap.Insert(10);
            ////minHeap.Insert(0);
            ////minHeap.Insert(12);
            ////minHeap.Print();

            ////var min = minHeap.ExtractMin();
            ////Console.WriteLine(min.Data);
            ////minHeap.Insert(13);
            ////minHeap.Print();

            ////min = minHeap.ExtractMin();
            ////Console.WriteLine(min.Data);
            ////minHeap.Print();
        }

        HeapNode<HuffmanNode>[] minHeap;
        int position;

        public MinHeapGeneric(int size)
        {
            this.minHeap = new HeapNode<HuffmanNode>[size];
            this.position = -1;
        }

        public void Insert(HeapNode<HuffmanNode> data)
        {
            if (this.position < 0)
            {
                this.minHeap[++this.position] = data;
            }
            else
            {
                this.minHeap[++this.position] = data;
                this.BubbleUp();
            }
        }

        public void BubbleUp()
        {
            var pos = this.position;
            var parent = (pos - 1) / 2;
            while (pos > 0 && (new MyComparator().Compare(this.minHeap[parent], this.minHeap[pos])) > 0)
            {
                //swap
                HeapNode<HuffmanNode> node = this.minHeap[parent];
                this.minHeap[parent] = this.minHeap[pos];
                this.minHeap[pos] = node;
                pos = parent;
                parent = (pos - 1) / 2;
            }
        }

        private void Swap(int a, int b)
        {
            //  System.out.println("swappinh" + mH[a] + " and " + mH[b]);
            HeapNode<HuffmanNode> temp = this.minHeap[a];
            this.minHeap[a] = this.minHeap[b];
            this.minHeap[b] = temp;
        }

        private void SinkDown(int k)
        {
            int smallest = k;
            var left = (2 * k) + 1;
            var right = (2 * k) + 2;
            if (((left <= this.position) && (new MyComparator().Compare(this.minHeap[smallest], this.minHeap[left])) > 0))
            {
                //left child
                smallest = left;
            }

            if (((right <= this.position) && (new MyComparator().Compare(this.minHeap[smallest],  this.minHeap[right])) > 0))
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
        public HeapNode<HuffmanNode> ExtractMin()
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
    }

    public interface IData
    {
        int data { get; set; }
    }
    public class HeapNode<T> where T: IData
    {
        public T Data { get; set; }
        public HeapNode(T data)
        {
            this.Data = data;
        }
    }
}
