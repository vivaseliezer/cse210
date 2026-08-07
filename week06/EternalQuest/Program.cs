/*
 * W06 Project: Eternal Quest Program
 * 
 * Creativity and Exceeding Core Requirements:
 * 1. Persistent Level and Experience Rank System:
 *    Calculates and displays a dynamic Level (calculated as Level = (Score / 1000) + 1)
 *    and a corresponding title Rank (Novice, Apprentice, Adventurer, Hero, or Legend)
 *    derived directly from the player's cumulative score.
 * 
 * 2. Visual & Audio Beep Fanfares:
 *    Implemented triumph beep melodies using Console.Beep() that play distinct fanfares
 *    when recording goal events, finishing checklist goals, and leveling up.
 * 
 * 3. Custom Negative Goals (Bad Habits):
 *    Implemented a custom 'NegativeGoal' type representing bad habits (e.g. limiting junk food).
 *    Recording this event deducts penalty points from the user's score to model realistic habit-breaking quest mechanics.
 * 
 * 4. Resilient File Handling & Safe Parsing:
 *    Uses the pipe '|' delimiter for string serialization instead of commas. This ensures 
 *    user-input names or descriptions that contain commas do not break the file format 
 *    during load operations. Includes try-catch blocks to prevent load crashes on file error.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}