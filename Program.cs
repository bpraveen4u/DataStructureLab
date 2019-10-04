using System;
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
                        HeapifyArray.Run();
                        break;
                    case "5":
                        Primes.Run();
                        break;
                    case "6":
                        CreateHash.Run();
                        break;
                    case "7":
                        Graph.Run();
                        break;
                    case "8":
                        GraphDijkstra.Run();
                        break;
                    case "9":
                        SortAlgorithms.Run(SortAlgorithm.Quick);
                        break;
                    case "10":
                        SortAlgorithms.Run(SortAlgorithm.Merge);
                        break;
                    case "11":
                        HuffmanCoding.Run();
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
            Console.WriteLine("4. Array Heapify");
            Console.WriteLine("5. Is Prime");
            Console.WriteLine("6. Hash"); 
            Console.WriteLine("7. Graph");
            Console.WriteLine("8. GraphDijkstra");
            Console.WriteLine("9. Quick Sort");
            Console.WriteLine("10. Merge Sort");
            Console.WriteLine("11. HuffmanCoding");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }
    }
}
