using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LINQ
{
    class Program
    {
        static IEnumerable<BigInteger> Fibonacci()      // IEnumerable<T> filters items on demand
        {
            BigInteger n1 = 0, n2 = 1;     // intialize with first terms in sequence
           
            while (true)        // infinite loop?
            {
                BigInteger fib = n1 + n2;
                
                yield return fib;     // returns one element at a time to the WHERE clause for evaluation

                n1 = n2;
                n2 = fib;
            }
        }

        static void Main(string[] args)
        {
            var evenFib = from n in Fibonacci()
                          where n % 2 == 0        // it is NOT filtering the entire result here; evaluates (the yield return) each element at a time.
                          select n;

           // var evenFib = Fibonacci().Where(n => n % 2 == 0);     // lambda(method) syntax
                      
            foreach (BigInteger n in evenFib)
            {
                Console.WriteLine(n);
                Console.ReadLine();
            }
        }
    }
}

