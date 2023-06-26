using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа разделенные пробелом :");
        string input = Console.ReadLine();
        int[] numbers = input.Split(' ').Select(int.Parse).ToArray();          //метод розділяє числа

        double product = numbers.Select(n => n % 10)                             // Отримуємо останню цифру кожного елемента
                               .Aggregate(1.0, (acc, digit) => acc * digit);             // Обчислюємо добуток цих цифр

        Console.WriteLine("Произвидение последних цифр всех елементов последовательности : " + product);
    }
}
