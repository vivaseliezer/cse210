using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Reflect on a moment when you felt guided by a higher purpose.",
        "Think of a time when you felt deeply connected to something greater than yourself.",
        "Recall a moment when your heart felt at peace and your spirit felt grounded.",
        "Consider a time when you experienced gratitude in a quiet and meaningful way.",
        "Remember a moment when you felt peace during a time of uncertainty.",
        "Think about a time when you sensed hope in the middle of difficulty.",
        "Recall a moment when your faith, values, or inner wisdom helped you choose wisely.",
        "Consider a time when you felt thankful for a simple blessing in your life.",
        "Think of a person who inspired you and helped you grow spiritually.",
        "Recall a moment when you discovered strength you did not know you had."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What emotions were present for you in that moment?",
        "How did this experience change the way you see yourself?",
        "What part of this experience felt most challenging?",
        "What lesson still stays with you today?",
        "How did others respond to your actions?",
        "What would you want to remember about that day?"
    };

    private List<string> _unusedPrompts = new List<string>();
    private List<string> _unusedQuestions = new List<string>();
    private Random _random = new Random();

    public ReflectingActivity() : base(
        "Reflecting",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        ResetPrompts();
        ResetQuestions();
    }

    private void ResetPrompts()
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    private void ResetQuestions()
    {
        _unusedQuestions = new List<string>(_questions);
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

    public string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            ResetQuestions();
        }
        int index = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return question;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"   --- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(8); // Display spinner for 8 seconds to give time for reflection
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
