/*
 * W05 Project: Mindfulness Program
 * 
 * Creativity and Exceeding Core Requirements:
 * 1. Persistent Session Statistics Logging:
 *    Implemented a StatsManager static class that appends every completed activity, 
 *    timestamp, and duration to a local text file ("stats.txt"). It aggregates this 
 *    data and displays a formatted summary table in the console (sessions completed, 
 *    total duration, and a list of the last 5 completed sessions).
 * 
 * 2. Uniqueness in Random Prompts and Questions:
 *    Implemented non-repeating random selection for ReflectingActivity questions/prompts 
 *    and ListingActivity prompts. The program tracks which items have been used 
 *    and will not select the same prompt or question again until the entire list has 
 *    been exhausted, ensuring a fresh experience.
 * 
 * 3. Dynamic Breathing Curve Animation:
 *    Instead of a simple numeric countdown, BreathingActivity utilizes an interactive, 
 *    non-linear visual indicator bar ([oooo...]). The breathing animation expands 
 *    and contracts dynamically, matching a sine wave curve to simulate a natural 
 *    human breath (inhaling/exhaling rapidly at first, then slowing down near the end).
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("                    MINDFULNESS PROGRAM                     ");
            Console.WriteLine("============================================================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity statistics");
            Console.WriteLine("  5. Quit");
            Console.WriteLine("============================================================");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                StatsManager.DisplayStats();
            }
            else if (choice == "5")
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}