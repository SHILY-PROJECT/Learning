using System.Collections.Generic;

namespace FibonacciSequenceDemo
{
    public class Sequence
    {
        public static IEnumerable<decimal> GetFibonacci()
        {
            var (past, next) = (-1L, 1L);

            while (true)
            {
                var sum = past + next;
                past = next;
                yield return next = sum;
            }
        }
    }
}
