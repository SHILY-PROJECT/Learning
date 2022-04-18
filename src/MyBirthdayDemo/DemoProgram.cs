using System;
using System.IO;
using System.Drawing;
using WMPLib;
using ColorConsole = Colorful;
using MyBirthdayDemo.Properties;

namespace MyBirthdayDemo;

internal class DemoProgram
{
    private record MyPersone(string Name, string Nickname, DateTime Birthday);

    public static void Main()
    {
        var persone = new MyPersone("SHILY", "Ilya", new DateTime(1995, 09, 13));

        var year = DateTime.Today.Month >= persone.Birthday.Month && DateTime.Today.Day > persone.Birthday.Day ? DateTime.Today.Year + 1 : DateTime.Today.Year;
        var result = (int)(new DateTime(year, persone.Birthday.Month, persone.Birthday.Day) - DateTime.Today).TotalDays;
        var font = Resources.big;        

        var musicFile = new FileInfo("music.mp3");
        File.WriteAllBytes(musicFile.FullName, Resources.MyBirthday_by_Flatingo);

        if (result == 0)
        {
            Console.SetWindowSize(160, 10);
            _ = musicFile.Exists && persone.Name == "Ilya" ? new WindowsMediaPlayer { URL = musicFile.FullName } : default;
            ColorConsole.Console.WriteLine(new ColorConsole.Figlet(ColorConsole.FigletFont.Load(font)).ToAscii("Happy Birthday to me...:)"), ColorTranslator.FromHtml("#008B8B"));
        }
        else Console.WriteLine($"Days left: {result}");
        
        Console.ReadKey();
    }
}