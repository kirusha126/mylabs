using System;
using System.IO;
using System.Text.Json;

class Time
{
    private int hours;
    private int minutes;
    private int seconds;

    public Time(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public int DifferenceInSeconds(Time otherTime)
    {
        int totalSeconds1 = this.seconds + (this.minutes * 60) + (this.hours * 3600);
        int totalSeconds2 = otherTime.seconds + (otherTime.minutes * 60) + (otherTime.hours * 3600);

        return Math.Abs(totalSeconds1 - totalSeconds2);
    }

    public void AddSeconds(int seconds)
    {
        int totalSeconds = this.seconds + (this.minutes * 60) + (this.hours * 3600);
        totalSeconds += seconds;

        this.hours = totalSeconds / 3600;
        totalSeconds %= 3600;
        this.minutes = totalSeconds / 60;
        this.seconds = totalSeconds % 60;
    }

    public void DisplayTime()
    {
        Console.WriteLine($"{hours:D2}:{minutes:D2}:{seconds:D2}");
    }

    public void SaveToJson(string fileName)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(fileName, json);
        Console.WriteLine("Object saved to JSON file.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the current time (hours minutes seconds):");
        string[] currentTimeInput = Console.ReadLine().Split(' ');
        int currentHours = int.Parse(currentTimeInput[0]);
        int currentMinutes = int.Parse(currentTimeInput[1]);
        int currentSeconds = int.Parse(currentTimeInput[2]);

        Console.WriteLine("Enter the new time (hours minutes seconds):");
        string[] newTimeInput = Console.ReadLine().Split(' ');
        int newHours = int.Parse(newTimeInput[0]);
        int newMinutes = int.Parse(newTimeInput[1]);
        int newSeconds = int.Parse(newTimeInput[2]);

        Time currentTime = new Time(currentHours, currentMinutes, currentSeconds);
        Time newTime = new Time(newHours, newMinutes, newSeconds);

        int differenceInSeconds = currentTime.DifferenceInSeconds(newTime);
        Console.WriteLine($"Difference in seconds: {differenceInSeconds}");

        Console.WriteLine("Enter the number of seconds to add:");
        int secondsToAdd = int.Parse(Console.ReadLine());
        currentTime.AddSeconds(secondsToAdd);

        Console.Write("Updated time: ");
        currentTime.DisplayTime();

        Console.WriteLine("Enter the file name to save the object:");
        string fileName = Console.ReadLine();
        currentTime.SaveToJson(fileName);
    }
}