using DataStuctureLab.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataStuctureLab
{
    public enum SortAlgorithm
    {
        Quick,
        Merge,
        Heap
    }
    public class SortAlgorithms
    {
        public static void Run(SortAlgorithm sortAlgorithm)
        {
            int[] arr = { 8, 2, 5, 3, 9, 4, 6 };
            arr.Dump();
            switch (sortAlgorithm)
            {
                case SortAlgorithm.Quick:
                    Console.WriteLine("Quick Sort");
                    QuickSort(arr, 0, arr.Length - 1);
                    break;
                case SortAlgorithm.Merge:
                    MergeSort(arr);
                    break;
                case SortAlgorithm.Heap:
                    Console.WriteLine("Not Implemented");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Sorted Array:");
            arr.Dump();
        }

        public static void QuickSort(int[] items, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(items, low, high);
                QuickSort(items, low, pi - 1);
                QuickSort(items, pi + 1, high);
            }
        }

        public static void MergeSort(int[] items)
        {
            Console.WriteLine("Merge Sort");
            var temp = new int[items.Length];
            MergeSort(items, temp, 0, items.Length - 1);
            //temp.Dump();
        }

        private static void MergeSort(int[] items, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart < rightEnd)
            {
                int mid = (leftStart + rightEnd) / 2;
                MergeSort(items, temp, leftStart, mid);
                MergeSort(items, temp, mid + 1, rightEnd);
                MergeItems(items, temp, leftStart, rightEnd);
            }
        }

        private static void MergeItems(int[] items, int[] temp, int leftStart, int rightEnd)
        {
            int mid = (leftStart + rightEnd) / 2;
            int leftEnd = mid;
            int rightStart = mid + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (items[left] <= items[right])
                {
                    temp[index++] = items[left++];
                }
                else
                {
                    temp[index++] = items[right++];
                }
            }

            while (left <= leftEnd)
            {
                temp[index++] = items[left++];
            }

            while (right <= rightEnd)
            {
                temp[index++] = items[right++];
            }

            ArrayCopy(temp, leftStart, items, leftStart, size);
        }

        private static void ArrayCopy(int[] source, int sourceIndex, int[] dest, int destIndex, int size)
        {
            //Console.WriteLine("size:" + size);
            int k = 0;
            int i = sourceIndex;
            int j = destIndex;
            while (k < size)
            {
                if (sourceIndex + k < source.Length && destIndex + k < dest.Length)
                    dest[sourceIndex + k] = source[destIndex + k];
                k++;
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
}
