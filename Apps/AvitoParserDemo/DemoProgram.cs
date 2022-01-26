using System;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using AvitoParserDemo.Models;

namespace AvitoParserDemo
{
    public class DemoProgram
    {
        public static void Main(string[] args)
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

            var htmlWeb = new HtmlWeb();
            var products = new List<AvitoItemModel>();

            var url = @"https://www.avito.ru/nizhniy_novgorod?p=2&q=rtx+3080";

            htmlWeb
                .Load(url)
                .DocumentNode.SelectNodes("//div[@data-marker='item']").ToList()
                .ForEach(x => products.Add(new AvitoItemModel
                {
                    Product = x.SelectNodes(".//h3[contains(@itemprop, 'name')]")[0].GetDirectInnerText(),
                    Price = x.SelectNodes(".//span[contains(@class, 'price-text')]")[0].GetDirectInnerText()
                }));

            if (products.Count != 0)
            {
                var maxProductNameLength = products.Select(x => x.Product.Length).Max();
                PrintColorText("Результат:", ConsoleColor.Blue);
                products.ForEach(x => Console.WriteLine($"Товар: {x.Product}{Indent(maxProductNameLength, x)}  |  Цена: {x.Price}"));
                
            }
            else PrintColorText("Простите, но по вашему запросу ничего не найдено...:(", ConsoleColor.Yellow);

            Console.ReadKey();
        }

        private static void PrintColorText(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string Indent(int maxProductNameLength, AvitoItemModel avitoItem)
            => new(' ', maxProductNameLength - avitoItem.Product.Length);
    }
}
