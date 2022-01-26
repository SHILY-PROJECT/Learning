using System;

namespace MyBirthdayDemo.Models
{
    public class MyPersone
    {
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public DateTime Birthday { get; private set; }

        public MyPersone(string nickname, string name, DateTime birthday)
        {
            Name = name;
            Nickname = nickname;
            Birthday = birthday;
        }
    }
}
