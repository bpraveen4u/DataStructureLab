using System;
using System.Collections.Generic;
using System.Text;

namespace DataStuctureLab
{
    class Primes
    {
        public static void Run()
        {
            Console.WriteLine("Is Prime\nThe following method checks if a number is prime by checking for divisibility on numbers less than it.\nIt only needs to go up to the square root of n because if n is divisible by a number greater than its square root then it's divisible by something smaller than it.");
            Console.WriteLine(IsPrime(3));
            Console.WriteLine(IsPrime(5));
            Console.WriteLine(IsPrime(13));
            Console.WriteLine(IsPrime(31));
            Console.WriteLine(IsPrime(99));
        }

        private static bool IsPrime(int n)
        {
            for (int x = 2; x * x < n; x++)
            {
                if (n % x == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
