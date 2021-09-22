using MyBirthday.Models;
using System;
using System.Drawing;
using System.Media;
using WMPLib;
using Print = Colorful.Console;
using Col = Colorful;

namespace MyBirthday
{
    public class MyBirthdayProgram
    {

        public static void Main()
        {
            var persone = new MyPersone("SHILY", "Ilya", new DateTime(1995, 09, 13));
            var year = DateTime.Today.Month >= persone.Birthday.Month && DateTime.Today.Day > persone.Birthday.Day ? DateTime.Today.Year + 1 : DateTime.Today.Year;
            var result = (int)(new DateTime(year, persone.Birthday.Month, persone.Birthday.Day) - DateTime.Today).TotalDays;

            if (result == 0)
            {
                _ = persone.Name == "Ilya" ? new WindowsMediaPlayer { URL = @"C:\Users\ILYA\Desktop\SHILY PROJECT\MyBirthday by Flatingo.mp3" } : default;
                Print.WriteLine(new Col.Figlet(Col.FigletFont.Load("big.flf")).ToAscii("Happy Birthday to me...:)"), ColorTranslator.FromHtml("#008B8B"));
            }
            else Console.WriteLine($"Days left: {result}");
            
            Console.ReadKey();
        }
    }

}
