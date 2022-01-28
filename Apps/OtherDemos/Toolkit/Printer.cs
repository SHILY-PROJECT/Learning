using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherDemos.Toolkit
{
    public class Printer
    {
        public static void PrintTitle(string title)
        {
            var numbSep = title.Length + 2;

            Console.WriteLine(
                $"{new string('═', numbSep)}╗" +
                $"\n {title} ║\n" +
                $"{new string('═', numbSep)}╝");
        }

        public static void PrintTitleAndValue(string title, string value)
        {
            PrintTitle(title);
            Console.WriteLine(value);
        }

        public static void PrintTitleAndValue(string title, string[] values)
        {
            PrintTitle(title);
            Array.ForEach(values, x =>  Console.WriteLine(x));
        }
    }
}
