using ExceptionTest.Models;
using System;
using System.Diagnostics;

namespace ExceptionTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var timerModel = new Stopwatch();
            var timerException = new Stopwatch();

            timerModel.Start();
            for (int i = 0; i < 1000; i++)
            {
                var content = new Content()
                {
                    IsSuccess = false,
                    Message = "Error"
                };

                if (!content.IsSuccess) { }
            }
            timerModel.Stop();

            Console.WriteLine($"Model: {timerModel.ElapsedMilliseconds} ms");

            timerException.Start();
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    throw new Exception("Error");
                }
                catch (Exception ex) { }
            }
            timerException.Stop();

            Console.WriteLine($"Exception: {timerException.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
