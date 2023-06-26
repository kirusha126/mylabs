using System;
using System.Collections.Generic;

abstract class Диск
{
    public double Розмір { get; set; }

    public Диск(double розмір)
    {
        Розмір = розмір;
    }

    public abstract void ВивестиРозмір();
}

class Директорія : Диск
{
    private List<Диск> обєкти;

    public Директорія(double розмір) : base(розмір)
    {
        обєкти = new List<Диск>();
    }

    public void ДодатиОбєкт(Диск обєкт)
    {
        обєкти.Add(обєкт);
    }

    public void ВивестиТипиОбєктів()
    {
        foreach (Диск обєкт in обєкти)
        {
            Console.WriteLine(обєкт.GetType().Name);
        }
    }

    public int КількістьАудіоФайлів()
{
    int кількість = 0;
    foreach (Диск обєкт in обєкти)
    {
        if (обєкт is Mp3)
        {
            кількість++;
        }
    }
    return кількість;
}

public override void ВивестиРозмір()
{
    Console.WriteLine($"Розмір директорії: {Розмір} МБ");
}
}

class Файл : Диск
{
    public Файл(double розмір) : base(розмір)
    {
    }

    public override void ВивестиРозмір()
    {
        Console.WriteLine($"Розмір файлу: {Розмір} МБ");
    }
}

class Архів : Диск
{
    public Архів(double розмір) : base(розмір)
    {
    }

    public override void ВивестиРозмір()
    {
        Console.WriteLine($"Розмір архіву: {Розмір} МБ");
    }
}

class Mp3 : Диск
{
    public Mp3(double розмір) : base(розмір)
    {
    }

    public override void ВивестиРозмір()
    {
        Console.WriteLine($"Розмір аудіофайлу: {Розмір} МБ");
    }

    public void Запустити()
    {
        Console.WriteLine("Файл запущено.");
    }
}

class ТекстовийФайл : Диск
{
    public ТекстовийФайл(double розмір) : base(розмір)
    {
    }

    public override void ВивестиРозмір()
    {
        Console.WriteLine($"Розмір текстового файлу: {Розмір} МБ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть розмір директорії:");
        double розмірДиректорії = Convert.ToDouble(Console.ReadLine());

        Директорія директорія = new Директорія(розмірДиректорії);

        Console.WriteLine("Введіть розмір файлу:");
        double розмірФайлу = Convert.ToDouble(Console.ReadLine());
        Файл файл = new Файл(розмірФайлу);

        Console.WriteLine("Введіть розмір архіву:");
        double розмірАрхіву = Convert.ToDouble(Console.ReadLine());
        Архів архів = new Архів(розмірАрхіву);

        Console.WriteLine("Введіть розмір аудіофайлу:");
        double розмірАудіоФайлу = Convert.ToDouble(Console.ReadLine());
        Mp3 mp3 = new Mp3(розмірАудіоФайлу);

        Console.WriteLine("Введіть розмір текстового файлу:");
        double розмірТекстовогоФайлу = Convert.ToDouble(Console.ReadLine());
        ТекстовийФайл текстовийФайл = new ТекстовийФайл(розмірТекстовогоФайлу);

        директорія.ДодатиОбєкт(файл);
        директорія.ДодатиОбєкт(архів);
        директорія.ДодатиОбєкт(mp3);
        директорія.ДодатиОбєкт(текстовийФайл);

        директорія.ВивестиТипиОбєктів();
        Console.WriteLine($"Кількість аудіофайлів: {директорія.КількістьАудіоФайлів()}");

        mp3.Запустити();

        директорія.ВивестиРозмір();
    }
}
