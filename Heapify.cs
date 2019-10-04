using System;
using System.Collections.Generic;
using System.Text;
using DataStuctureLab.Extensions;

namespace DataStuctureLab
{
    public class HeapifyArray
    {
        public static void Run()
        {
            Console.WriteLine("Build Heap array");
            int[] arr = { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17 };
            Console.WriteLine("Existing Array:");
            arr.Dump();
            BuildHeapArray(arr, arr.Length);
            Console.WriteLine("Heapify Array:");
            arr.Dump();

        }

        // To heapify a subtree rooted with node i which is  
        // an index in arr[]. n is size of heap 
        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than root  
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // If right child is larger than largest so far  
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // If largest is not root  
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree  
                Heapify(arr, n, largest);
            }
        }

        public static void BuildHeapArray(int[] arr, int n)
        {
            // Index of last non-leaf node  
            int startIdx = (n / 2) - 1;

            // Perform reverse level order traversal  
            // from last non-leaf node and heapify  
            // each node  
            for (int i = startIdx; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
        }
    }
}
