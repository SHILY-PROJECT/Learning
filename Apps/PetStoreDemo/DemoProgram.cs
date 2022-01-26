using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PetStoreDemo.Enums;
using PetStoreDemo.Models;

namespace PetStoreDemo
{
    public class DemoProgram
    {
        private static readonly Dictionary<int, string> PetInventoryStatusForConsoleView = new Dictionary<int, string>
        {
            { (int)PetInventoryStatus.Available, "Доступно" },
            { (int)PetInventoryStatus.Pending, "В ожидании" },
            { (int)PetInventoryStatus.Sold, "Продано" }
        };

        public static void Main(string[] args)
        {
            int startingPosition, finalPosition, currentPosition;

            ConsoleKey key;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Выберите статус:");
            Console.ResetColor();

            startingPosition = currentPosition = Console.CursorTop;

            Console.CursorSize = 50;
            Console.CursorTop = startingPosition;

            foreach (var element in PetInventoryStatusForConsoleView) Console.WriteLine($" {element.Value}");

            finalPosition = Console.CursorTop;
            Console.CursorTop = startingPosition;
            
            while (true)
            {
                if ((key = Console.ReadKey(true).Key) == ConsoleKey.Enter) break;

                if (key == ConsoleKey.UpArrow)
                {
                    if (currentPosition > startingPosition)
                    {
                        --currentPosition;
                        Console.CursorTop = currentPosition;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (currentPosition < finalPosition - 1)
                    {
                        ++currentPosition;
                        Console.CursorTop = currentPosition;
                    }
                }
            }
            
            Console.CursorTop = finalPosition;

            Console.WriteLine($"\n-->{PetInventoryStatusForConsoleView.GetValueOrDefault(currentPosition)}\n");

            var response = GetInventory();
            
            var fullInventory = JsonConvert.DeserializeObject<InventoryModel>(response);
            var toConsole = new List<string>
            {
                $"Доступно: {fullInventory.Available}",
                $"В ожидании: {fullInventory.Pending}",
                $"Продано: {fullInventory.Sold}"
            };
            toConsole.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
        }

        public static int GetInventoryByStatus(string status, InventoryModel fullInventory)
        {
            return status switch
            {
                "Available" => fullInventory.Available,
                "Pending" => fullInventory.Pending,
                "Sold" => fullInventory.Sold,
                _ => throw new Exception("Неизвестный статус"),
            };
        }

        /// <summary>
        /// Получение инвентаря домашних питомцев.
        /// </summary>
        /// <returns></returns>
        private static string GetInventory()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = httpClient.GetAsync("https://petstore.swagger.io/v2/store/inventory").Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }

}
