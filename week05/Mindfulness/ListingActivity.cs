using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "List people that you appreciate.",
        "List personal strengths of yours.",
        "List people that you have helped this week.",
        "List when you have felt the Holy Ghost this week.",
        "List some of your personal heroes."
    };

    private List<string> _unusedPrompts = new List<string>();
    private Random _random = new Random();

    public ListingActivity() : base(
        "Listing", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        ResetPrompts();
    }

    private void ResetPrompts()
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            ResetPrompts();
        }
        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }
        return items;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"   --- {prompt} ---\n");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"\nYou listed {_count} items!");
        
        DisplayEndingMessage();
    }
}
