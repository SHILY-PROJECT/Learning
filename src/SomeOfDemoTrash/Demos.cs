using SomeOfDemoTrash.Trashcan;

namespace SomeOfDemoTrash;

internal class Demos
{
    public static void StartDemoExtractSizeFromBytes()
    {
        var dataSet = new[] { 952, 1024, 1551, 5562, 55646546, 56466621616, 876666216163, 2746666216163 };

        Printer.PrintTitle("VARIABLE HANDLER ║ ExtractSizeFromBytes");

        Array.ForEach(dataSet, value =>
        {
            var res = Extractor.ExtractSizeFromBytes(value);
            Console.WriteLine(res);
        });

        Console.WriteLine();
        Console.ReadKey();
    }

    public static void StartDemoListExtensions()
    {
        var list = new List<string> { "one", "two", "three", "four", "five" };

        Printer.PrintTitle("LIST EXTENSIONS ║ GetRandomLineWithRemoved");

        Console.WriteLine("Output: " + list.GetLine(LineOption.GetRandomLineWithRemoved) + Environment.NewLine);
        list.ForEach(line => Console.WriteLine(line));

        Console.WriteLine();
        Console.ReadKey();
    }

    public static void StartDemoExtractFibonacci(string[] args)
    {
        var sequence = Extractor.ExtractFibonacci().Take(30).ToArray();
        Console.WriteLine(string.Join(", ", sequence));
        Console.ReadKey();
    }

    public static void StartDemoScrollingWithButtons()
    {
        try
        {
            WeaponScroller.ScrollingWithButtons();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    public static void StartDemoCreateString()
    {
        Printer.PrintTitle("TEXT MACROS ║ CreateString");

        new Func<string>[]
        {
            () => TextMacros.CreateString(10, "a"),
            () => TextMacros.CreateString(15, "ab"),
            () => TextMacros.CreateString(20, "abc"),
            () => TextMacros.CreateString(25, "abcd")
        }
        .ToList().ForEach(f => Console.WriteLine(f.Invoke()));
        
        Console.ReadKey();
    }
}