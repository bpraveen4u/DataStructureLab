using System;
using System.Collections.Generic;
using System.Text;

namespace DataStuctureLab
{
    class CreateHash
    {
        public static void Run()
        {
            Console.WriteLine("Create the hash World");
            Console.WriteLine(CreateHashInternal("a"));
            Console.WriteLine(CreateHashInternal("A"));
            Console.WriteLine(CreateHashInternal("ab"));
            Console.WriteLine(CreateHashInternal("az"));
            Console.WriteLine(CreateHashInternal("acb88"));
            Console.WriteLine(CreateHashInternal("acb88"));
        }

        public static long CreateHashInternal(string s)
        {
            Console.Write("Hash for '{0}': ", s);
            long hash = 0;
            int prime = 17;
            for (int i = 0; i < s.Length; i++)
            {
                hash += s[i] * ((long)Math.Pow(prime, i));
            }

            return hash;
        }
    }
}
