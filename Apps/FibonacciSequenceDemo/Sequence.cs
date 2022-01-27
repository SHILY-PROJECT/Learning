using System.Collections.Generic;

namespace FibonacciSequenceDemo
{
    public class Sequence
    {
        public static IEnumerable<decimal> GetFibonacci()
        {
            var (prev, current) = (-1L, 1L);

            while (true)
            {
                var next = prev + current;
                prev = current;
                yield return current = next;
            }
        }
    }
}
