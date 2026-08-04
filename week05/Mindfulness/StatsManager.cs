using System;
using System.IO;
using System.Collections.Generic;

public static class StatsManager
{
    private static readonly string Filename = "stats.txt";

    public static void LogActivity(string name, int duration)
    {
        try
        {
            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{name}|{duration}";
            File.AppendAllText(Filename, logLine + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save statistics: {ex.Message}");
        }
    }

    public static void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine("============================================================");
        Console.WriteLine("                    ACTIVITY STATISTICS                     ");
        Console.WriteLine("============================================================");
        Console.WriteLine();

        if (!File.Exists(Filename))
        {
            Console.WriteLine("No sessions have been recorded yet.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(Filename);
            Dictionary<string, int> counts = new Dictionary<string, int>
            {
                { "Breathing", 0 },
                { "Reflecting", 0 },
                { "Listing", 0 }
            };
            Dictionary<string, int> totalTime = new Dictionary<string, int>
            {
                { "Breathing", 0 },
                { "Reflecting", 0 },
                { "Listing", 0 }
            };

            int totalSessions = 0;
            int overallTime = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string name = parts[1];
                    if (int.TryParse(parts[2], out int duration))
                    {
                        if (counts.ContainsKey(name))
                        {
                            counts[name]++;
                            totalTime[name] += duration;
                        }
                        else
                        {
                            counts[name] = 1;
                            totalTime[name] = duration;
                        }
                        totalSessions++;
                        overallTime += duration;
                    }
                }
            }

            Console.WriteLine($"{"Activity Type",-15} | {"Sessions Completed",-20} | {"Total Duration (s)",-18}");
            Console.WriteLine(new string('-', 60));
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key,-15} | {kvp.Value,-20} | {totalTime[kvp.Key],-18}");
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"TOTAL",-15} | {totalSessions,-20} | {overallTime,-18}");
            Console.WriteLine();

            Console.WriteLine("Recent Sessions:");
            int startIdx = Math.Max(0, lines.Length - 5);
            for (int i = lines.Length - 1; i >= startIdx; i--)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split('|');
                if (parts.Length == 3)
                {
                    Console.WriteLine($" - {parts[0]}: {parts[1]} Activity ({parts[2]} seconds)");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading statistics: {ex.Message}");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
