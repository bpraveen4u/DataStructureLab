﻿using System;
using System.IO;

namespace DataStuctureLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structure Play Ground");

            bool flag = true;

            while (flag)
            {
                DisplayOptions();
                var op = Console.ReadLine();

                switch (op)
                {
                    case "0":
                        flag = false;
                        break;
                    case "1":
                        MinHeap.Run();
                        break;
                    case "2":
                        AVL.Run();
                        break;
                    case "3":
                        MergeKSortedArrays.Run();
                        break;
                    case "4":
                        Primes.Run();
                        break;
                    default:
                        Console.WriteLine("Select Correct Option");
                        DisplayOptions();
                        break;
                }
            }
        }

        static void DisplayOptions()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Please select options by typing number and pressing Enter key.");
            Console.WriteLine("1. MinHeap");
            Console.WriteLine("2. AVL Tree");
            Console.WriteLine("3. Merge K Sorted Arrays");
            Console.WriteLine("4. Is Prime");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }
    }
}