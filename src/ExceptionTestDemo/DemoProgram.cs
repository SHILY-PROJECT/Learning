using System;
using System.Diagnostics;

namespace ExceptionTestDemo;

internal class DemoProgram
{
    private record Content(string Message, bool IsSuccess);

    public static void Main(string[] args)
    {
        var timerModel = new Stopwatch();
        var timerException = new Stopwatch();

        timerModel.Start();
        for (int i = 0; i < 1000; i++)
        {
            var content = new Content("Error", false);

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
            catch { }
        }
        timerException.Stop();

        Console.WriteLine($"Exception: {timerException.ElapsedMilliseconds} ms");

        Console.ReadKey();
    }
}