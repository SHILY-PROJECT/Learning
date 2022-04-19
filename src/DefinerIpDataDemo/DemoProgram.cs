using SomeOfDemoTrash.Trashcan;
using DefinerIpDataDemo.Core;
using DefinerIpDataDemo.Core.Models;

new List<(string country, string ip)>
{
    ("CURRENT", ""),
    ("GERMANY", "173.212.213.133"),
    ("UNITED KINGDOM", "142.93.44.47"),
    ("LATVIA", "93.177.198.114"),
    ("FRANCE", "164.132.137.241"),
    ("NORWAY", "84.247.130.114"),
    ("NETHERLANDS", "31.161.38.233")
}
.ForEach(x =>
{
    if (Definer.TryDefineIpData(x.ip, out var ipData))
    {
        Printer.PrintTitle($"DEMO {x.country} IP DATA");
        Print(ipData);
        Console.WriteLine("\n");
    }
});

Console.ReadLine();

static void Print(IpData user)
{
    var props = user.GetType().GetProperties();
    var maxLength = props.Max(x => x.Name.Length) + 5;

    foreach(var p in props)
    {
        if (p.GetValue(user)?.ToString() is string value && !string.IsNullOrEmpty(value))
        {
            var indent = new string(' ', (maxLength - p.Name.Length));
            Console.WriteLine($"{p.Name}:{indent}{value}");
        }
    }
}