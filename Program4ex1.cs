using System;

// Клас, що представляє окремий елемент масиву
class Element
{
    public int Value { get; set; }

    public Element(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

// Клас, що представляє одновимірний масив                            //У цій програмі є два класи - Element і Array.
class Array
{
    private Element[] elements;

    public Array(int size)
    {
        elements = new Element[size];
    }

    public Element this[int index]
    {
        get { return elements[index]; }
        set { elements[index] = value; }
    }

    public void Display()
    {
        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine();
    }

    public Array Add(Array otherArray)
    {
        if (elements.Length != otherArray.elements.Length)
        {
            throw new ArgumentException("Розміри масивів не співпадають");
        }

        Array resultArray = new Array(elements.Length);
        for (int i = 0; i < elements.Length; i++)
        {
            resultArray[i] = new Element(elements[i].Value + otherArray[i].Value);
        }
        return resultArray;
    }

    public Array Subtract(Array otherArray)
    {
        if (elements.Length != otherArray.elements.Length)
        {
            throw new ArgumentException("Розміри масивів не співпадають");
        }

        Array resultArray = new Array(elements.Length);
        for (int i = 0; i < elements.Length; i++)
        {
            resultArray[i] = new Element(elements[i].Value - otherArray[i].Value);
        }
        return resultArray;
    }

    public Array Multiply(Array otherArray)
    {
        if (elements.Length != otherArray.elements.Length)
        {
            throw new ArgumentException("Розміри масивів не співпадають");
        }

        Array resultArray = new Array(elements.Length);
        for (int i = 0; i < elements.Length; i++)
        {
            resultArray[i] = new Element(elements[i].Value * otherArray[i].Value);
        }
        return resultArray;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть розмір масиву:");
        int size = int.Parse(Console.ReadLine());

        Array array1 = CreateArray(size);
        Array array2 = CreateArray(size);

        Console.WriteLine("\nМасив 1:");
        array1.Display();

        Console.WriteLine("\nМасив 2:");
        array2.Display();

        Console.WriteLine("\nРезультат додавання масивів:");
        Array sumArray = array1.Add(array2);
        sumArray.Display();

        Console.WriteLine("\nРезультат віднімання масивів:");
        Array subtractArray = array1.Subtract(array2);
        subtractArray.Display();

        Console.WriteLine("\nРезультат множення масивів:");
        Array multiplyArray = array1.Multiply(array2);
        multiplyArray.Display();
    }

    static Array CreateArray(int size)
    {
        Array array = new Array(size);

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Введіть значення для елемента {i + 1}:");
            int value = int.Parse(Console.ReadLine());
            array[i] = new Element(value);
        }

        return array;
    }
}