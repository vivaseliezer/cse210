using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("============================================================");
            Console.WriteLine("                    ETERNAL QUEST MENU                      ");
            Console.WriteLine("============================================================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine("============================================================");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("The goals are:");
                ListGoalDetails();
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing Eternal Quest! Keep striving towards your goals.");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        // Level increases every 1000 points, starting at Level 1 (clamped to 1 if negative score)
        int level = Math.Max(1, (_score / 1000) + 1);

        // Rank names based on points
        string rank;
        if (_score < 1000) rank = "Novice";
        else if (_score < 3000) rank = "Apprentice";
        else if (_score < 6000) rank = "Adventurer";
        else if (_score < 10000) rank = "Hero";
        else rank = "Legend";

        Console.WriteLine($"Score: {_score} points");
        Console.WriteLine($"Rank: Level {level} ({rank})");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals defined yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal (A single check-off goal, e.g. run a marathon)");
        Console.WriteLine("  2. Eternal Goal (A recurring goal, e.g. read scriptures daily)");
        Console.WriteLine("  3. Checklist Goal (Must be completed multiple times, e.g. attend temple 10 times)");
        Console.WriteLine("  4. Negative Goal (Break a bad habit, e.g. limit junk food - penalty applied)");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3" && typeChoice != "4")
        {
            Console.WriteLine("\nInvalid type selected. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            string prompt = typeChoice == "4" ? "What is the penalty points deducted? " : "What is the amount of points associated with this goal? ";
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out points) && points >= 0)
            {
                break;
            }
            Console.WriteLine("Please enter a valid non-negative integer.");
        }

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            int target;
            while (true)
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (int.TryParse(Console.ReadLine(), out target) && target > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid integer greater than 0.");
            }

            int bonus;
            while (true)
            {
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (int.TryParse(Console.ReadLine(), out bonus) && bonus >= 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid non-negative integer.");
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (typeChoice == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }

        Console.WriteLine("\nGoal created successfully! Press Enter to return to the menu...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record events for.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];

            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("\nThis goal is already completed!");
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
                return;
            }

            int levelBefore = Math.Max(1, (_score / 1000) + 1);
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;
            int levelAfter = Math.Max(1, (_score / 1000) + 1);

            if (pointsEarned < 0)
            {
                Console.WriteLine($"\nOh no! You recorded a bad habit: '{selectedGoal.GetShortName()}'.");
                Console.WriteLine($"You lost {Math.Abs(pointsEarned)} points!");
            }
            else
            {
                Console.WriteLine($"\nCongratulations! You recorded progress for: '{selectedGoal.GetShortName()}'.");
                Console.WriteLine($"You earned {pointsEarned} points!");
                
                // Play victory sound effect
                if (selectedGoal.IsComplete())
                {
                    Console.WriteLine("HURRAH! You fully completed the goal!");
                    PlayVictoryFanfare();
                }
                else
                {
                    PlayAccomplishBeep();
                }

                // Check for level up
                if (levelAfter > levelBefore)
                {
                    Console.WriteLine($"\n✨ LEVEL UP! You reached Level {levelAfter}! ✨");
                    PlayLevelUpSound();
                }
            }
        }
        else
        {
            Console.WriteLine("\nInvalid goal number selected.");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals saved successfully to '{filename}'!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving goals: {ex.Message}");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nError: The file '{filename}' was not found.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("\nError: The file is empty.");
                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
                return;
            }

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                int colonIndex = line.IndexOf(':');
                if (colonIndex == -1) continue;

                string type = line.Substring(0, colonIndex);
                string details = line.Substring(colonIndex + 1);
                string[] parts = details.Split('|');

                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[3]);
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int amountCompleted = int.Parse(parts[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }
                else if (type == "NegativeGoal")
                {
                    _goals.Add(new NegativeGoal(name, description, points));
                }
            }
            Console.WriteLine($"\nGoals loaded successfully! Your loaded score is {_score}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading goals: {ex.Message}");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    private void PlayAccomplishBeep()
    {
        try
        {
            Console.Beep(587, 100); // D5
            Console.Beep(880, 200); // A5
        }
        catch (Exception)
        {
            // Ignore OS Beep exceptions
        }
    }

    private void PlayVictoryFanfare()
    {
        try
        {
            Console.Beep(523, 150); // C5
            Console.Beep(659, 150); // E5
            Console.Beep(784, 150); // G5
            Console.Beep(1046, 400); // C6
        }
        catch (Exception)
        {
            // Ignore
        }
    }

    private void PlayLevelUpSound()
    {
        try
        {
            Console.Beep(440, 100); // A4
            Console.Beep(554, 100); // C#5
            Console.Beep(659, 100); // E5
            Console.Beep(880, 200); // A5
            Console.Beep(659, 100); // E5
            Console.Beep(880, 400); // A5
        }
        catch (Exception)
        {
            // Ignore
        }
    }
}
