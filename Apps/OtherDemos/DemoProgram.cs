DemoExtractSizeFromBytes();
DemoListExtensions();

Console.ReadKey();

static void DemoExtractSizeFromBytes()
{
    var dataSet = new[] { 952, 1024, 1551, 5562, 55646546, 56466621616, 876666216163, 2746666216163 };

    Printer.PrintTitle("VARIABLE HANDLER ║ ExtractSizeFromBytes");

    Array.ForEach(dataSet, value =>
    {
        var res = VariableHandler.ExtractSizeFromBytes(value);
        Console.WriteLine(res);
    });
    Console.WriteLine();
}

static void DemoListExtensions()
{
    var list = new List<string> { "one", "two", "three", "four", "five" };

    Printer.PrintTitle("LIST EXTENSIONS ║ GetRandomLineWithRemoved");

    Console.WriteLine("Output: " + list.GetLine(LineOption.GetRandomLineWithRemoved) + Environment.NewLine);
    list.ForEach(line => Console.WriteLine(line));
    Console.WriteLine();
}