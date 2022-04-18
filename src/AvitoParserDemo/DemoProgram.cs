using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using AvitoParserDemo.Core;
using AvitoParserDemo.Core.Model;

namespace AvitoParserDemo;

internal class DemoProgram
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        StartDemoAvitoParser();
        Console.ReadKey();
    }

    private static void StartDemoAvitoParser()
    {
        Console.WriteLine("Для начала парсинга нажмите Enter...");

        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                PrintColorText("Старт парсинга. Пожалуйста, подождите...", ConsoleColor.Green);
                break;
            }
        }

        var url = @"https://www.avito.ru/nizhniy_novgorod?p=2&q=rtx+3080";

        if (AvitoParser.Parse(url) is IEnumerable<AvitoItem> products && products.Any())
        {
            var maxProductNameLength = products.Select(x => x.Product.Length).Max();
            PrintColorText("Результат:", ConsoleColor.Blue);
            products.ToList().ForEach(x => Console.WriteLine($"Товар: {x.Product}{AdjustIndent(maxProductNameLength, x)}  |  Цена: {x.Price}"));
        }
        else PrintColorText("Простите, но по вашему запросу ничего не найдено...:(", ConsoleColor.Yellow);
    }

    private static void PrintColorText(string text, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    private static string AdjustIndent(int maxProductNameLength, AvitoItem avitoItem)
        => new(' ', maxProductNameLength - avitoItem.Product.Length);
}