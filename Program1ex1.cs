using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Введите числа");
        string input = Console.ReadLine();
        while (!string.IsNullOrEmpty(input))
        {
            if (int.TryParse(input, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Введено недействительное число. Пожалуйста, попробуйте еще раз.");
            }

            input = Console.ReadLine();
        }

        int startIndex = 0;
        int endIndex = numbers.Count - 1;

        while (startIndex < endIndex)
        {
            if (numbers[startIndex] < 0)
            {
                startIndex++;
            }
            else if (numbers[endIndex] >= 0)
            {
                endIndex--;
            }
            else
            {
                int temp = numbers[startIndex];
                numbers[startIndex] = numbers[endIndex];
                numbers[endIndex] = temp;
                startIndex++;
                endIndex--;
            }
        }

        Console.WriteLine("Ответ :");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }
}
