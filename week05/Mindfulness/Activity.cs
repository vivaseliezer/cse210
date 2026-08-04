using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        
        string input = Console.ReadLine();
        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 30; // Default to 30 seconds if input is invalid
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        StatsManager.LogActivity(_name, _duration);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            string character = spinnerChars[index];
            Console.Write(character);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % spinnerChars.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            // Handle deleting characters depending on digit count
            int length = i.ToString().Length;
            for (int j = 0; j < length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
