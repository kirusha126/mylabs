using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();             //створюеться словник
                                                                                           //ключ дядок, значення ціле число

        Console.WriteLine("Введите  данные для создания словника:");
        string key = Console.ReadLine();
        while (!string.IsNullOrEmpty(key))
        {
            Console.WriteLine("Введіть значення для ключа \"{0}\":", key);
            string valueInput = Console.ReadLine();
            if (int.TryParse(valueInput, out int value))
            {
                dictionary[key] = value;
            }
            else
            {
                Console.WriteLine("Введено недействительное значение . Пожалуйста, попробуйте еще  раз.");
            }

            key = Console.ReadLine();
        }

        Dictionary<string, int> updatedDictionary = new Dictionary<string, int>();     //створюється новий словник

        int sum = 0;
        foreach (var kvp in dictionary)
        {
            sum += kvp.Value;
        }

        foreach (var kvp in dictionary)
        {
            updatedDictionary[kvp.Key] = sum;
        }

        string json = JsonSerializer.Serialize(updatedDictionary);        //коли словник готовий він конвертується у джисон

        File.WriteAllText("result.json", json);

        Console.WriteLine("Пезультат сохранен в  result.json.");
    }
}
