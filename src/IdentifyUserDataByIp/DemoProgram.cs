using SomeOfDemoTrash.Trashcan;
using IdentifyUserDataByIp.Core;
using IdentifyUserDataByIp.Core.Models;

if (Detector.TryDefineIpData(out var userDataWithCurrentIp))
{
    Printer.PrintTitle("DEMO CURRENT IP DATA");
    Print(userDataWithCurrentIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("173.212.213.133", out var userDataWithGermanyIp))
{
    Printer.PrintTitle("DEMO GERMANY IP DATA");
    Print(userDataWithGermanyIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("142.93.44.47", out var userDataWithUnitedKingdomIp))
{
    Printer.PrintTitle("DEMO UNITED KINGDOM IP DATA");
    Print(userDataWithUnitedKingdomIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("93.177.198.114", out var userDataWithLatviaIp))
{
    Printer.PrintTitle("DEMO LATVIA IP DATA");
    Print(userDataWithLatviaIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("164.132.137.241", out var userDataWithFranceIp))
{
    Printer.PrintTitle("DEMO FRANCE IP DATA");
    Print(userDataWithFranceIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("84.247.130.114", out var userDataWithNorwayIp))
{
    Printer.PrintTitle("DEMO NORWAY IP DATA");
    Print(userDataWithNorwayIp);
    Console.WriteLine("\n");
}

if (Detector.TryDefineIpData("31.161.38.233", out var userDataWithNetherlandsIp))
{
    Printer.PrintTitle("DEMO NETHERLANDS IP DATA");
    Print(userDataWithNetherlandsIp);
    Console.WriteLine("\n");
}

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