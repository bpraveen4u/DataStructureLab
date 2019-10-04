using System;
using System.Collections.Generic;
using System.Text;

namespace DataStuctureLab.Extensions
{
    public static class Extensions
    {
        public static void Dump(this int[] arr)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.Write("]");

            Console.WriteLine();
        }

        public static void Dump(this double[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                Console.Write("[");
                
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write(arr[row, col] + " ");
                }
                Console.Write("]");

                Console.WriteLine();
            }
        }
    }
}
