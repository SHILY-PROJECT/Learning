using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using AvitoParserDemo.Core.Model;

namespace AvitoParserDemo.Core;

internal class AvitoParser
{
    public static IEnumerable<AvitoItem> Parse(string url)
    {
        return Task.Run(async () =>
        {
            var htmlWeb = new HtmlWeb();
            var products = new List<AvitoItem>();

            var html = await htmlWeb.LoadFromWebAsync(url);

            html.DocumentNode
                .SelectNodes("//div[@data-marker='item']").ToList()
                .ForEach(x => products.Add(new AvitoItem
                {
                    Price = x.SelectNodes(".//h3[contains(@itemprop, 'name')]")[0].GetDirectInnerText(),
                    Product = x.SelectNodes(".//span[contains(@class, 'price-text')]")[0].GetDirectInnerText()
                }));

            return products;
        })
        .Result;
    }
}