using System;
using System.Collections.Generic;
using System.Linq;

// Базовий клас "Квітка"                            //У цій програмі створюються класи "Квітка", "Роза", "Тюльпан" і "Букет".
                                                    // Клас "Квітка" є базовим класом для "Рози" і "Тюльпана".
                                                    // Кожен клас має свої властивості і методи, а також перевизначені методи
                                                    // Display для виведення інформації про об'єкти на консоль. Клас "Букет" має
                                                    // методи для додавання квітів до букету, обчислення вартості букету, сортування
                                                    // квітів за рівнем свіжості, виведення букету на консоль та пошуку квітки за довжиною
                                                    // стебла в заданому діапазоні.
class Flower
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int FreshnessLevel { get; set; }
    public int StemLength { get; set; }
    public Flower(string name, double price, int freshnessLevel)
    {
        Name = name;
        Price = price;
        FreshnessLevel = freshnessLevel;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Квітка: {Name}");
        Console.WriteLine($"Ціна: {Price}");
        Console.WriteLine($"Рівень свіжості: {FreshnessLevel}");
    }
}

// Клас "Роза" - підклас класу "Квітка"
class Rose : Flower
{
    public string Color { get; set; }

    public Rose(string name, double price, int freshnessLevel, string color)
        : base(name, price, freshnessLevel)
    {
        Color = color;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Колір: {Color}");
    }
}

// Клас "Тюльпан" - підклас класу "Квітка"
class Tulip : Flower
{
    public string Origin { get; set; }

    public Tulip(string name, double price, int freshnessLevel, string origin)
        : base(name, price, freshnessLevel)
    {
        Origin = origin;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Походження: {Origin}");
    }
}

// Клас "Букет"
class Bouquet
{
    private List<Flower> flowers;

    public Bouquet()
    {
        flowers = new List<Flower>();
    }

    public void AddFlower(Flower flower)
    {
        flowers.Add(flower);
    }

    public double CalculatePrice()
    {
        return flowers.Sum(flower => flower.Price);
    }

    public void SortByFreshness()
    {
        flowers.Sort((flower1, flower2) => flower2.FreshnessLevel.CompareTo(flower1.FreshnessLevel));
    }

    public void Display()
    {
        Console.WriteLine("Букет:");
        foreach (var flower in flowers)
        {
            flower.Display();
            Console.WriteLine();
        }
    }
    
    public Flower FindFlowerByStemLength(int minLength, int maxLength)
    {
        return flowers.FirstOrDefault(flower => flower is Rose && ((Rose)flower).StemLength >= minLength && ((Rose)flower).StemLength <= maxLength);
    }
}

class Program
{
    static void Main()
    {
        Bouquet bouquet = new Bouquet();

        Rose redRose = new Rose("Червона троянда", 10.5, 5, "Червоний");
        Rose whiteRose = new Rose("Біла троянда", 9.2, 4, "Білий");
        Tulip yellowTulip = new Tulip("Жовтий тюльпан", 7.8, 6, "Голландія");

        bouquet.AddFlower(redRose);
        bouquet.AddFlower(whiteRose);
        bouquet.AddFlower(yellowTulip);

        Console.WriteLine("Додано квіти до букету.");

        double bouquetPrice = bouquet.CalculatePrice();
        Console.WriteLine($"Вартість букету: {bouquetPrice}");

        bouquet.SortByFreshness();
        Console.WriteLine("Букет відсортовано за рівнем свіжості.");

        bouquet.Display();

        int minLength = 5;
        int maxLength = 10;
        Flower foundFlower = bouquet.FindFlowerByStemLength(minLength, maxLength);
        if (foundFlower != null)
        {
            Console.WriteLine($"Знайдено квітку з довжиною стебла в діапазоні {minLength}-{maxLength}:");
            foundFlower.Display();
        }
        else
        {
            Console.WriteLine($"Квітку з довжиною стебла в діапазоні {minLength}-{maxLength} не знайдено.");
        }
    }
}