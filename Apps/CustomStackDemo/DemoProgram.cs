using System;
using CustomStackDemo.CustomCollections;

namespace CustomStackDemo
{
    internal class DemoProgram
    {
        internal static void Main(string[] args)
        {
            Demo();
            Console.ReadKey();
        }

        private static void Demo()
        {
            var stack = new CustomStack<string>();

            //____________________________________________________
            PrintTitle("CUSTOM STACK DEMO ║ Push & Peek");

            AddItemsToStack(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek() + Environment.NewLine);

            //____________________________________________________
            PrintTitle("CUSTOM STACK DEMO ║ Pop");
            Console.WriteLine(stack.Pop() + stack.Pop());
            Console.WriteLine(stack.Pop() + stack.Pop() + Environment.NewLine);

            //____________________________________________________
            PrintTitle("CUSTOM STACK DEMO ║ Push & GetEnumerator -> MoveNext -> Current -> Reset");

            AddItemsToStack(stack);
            var enumerator = stack.GetEnumerator();

            for (int i = 0; i < 2; i++)
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);

                enumerator.Reset();
                Console.WriteLine();
            }
        }

        private static void AddItemsToStack(CustomStack<string> stack)
        {
            stack.Push("SHILY!");
            stack.Push("Hello ");
            stack.Push("World!");
            stack.Push("Hello ");
        }

        private static void PrintTitle(string title)
        {
            var numbSep = title.Length + 2;

            Console.WriteLine(
                $"{new string('═', numbSep)}╗" +
                $"\n {title} ║\n" +
                $"{new string('═', numbSep)}╝");
        }

    }
}
