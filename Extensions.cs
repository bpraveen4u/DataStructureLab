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
    }
}
