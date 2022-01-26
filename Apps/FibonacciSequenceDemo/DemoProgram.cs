using System;
using System.Linq;

namespace FibonacciSequenceDemo
{
    internal class DemoProgram
    {
        internal static void Main(string[] args)
        {
            var sequence = Sequence.GetFibonacci().Take(30).ToList();
            Console.WriteLine(string.Join(", ", sequence));
            Console.ReadKey();
        }
    }
}
