using System;
using System.Collections.Generic;

public class Entry
{
    public string _prompt = "";
    // response is storing what the user replies to the prompt
    public string _response = "";
    // get current Date
    public DateTime _currentDate = DateTime.Now;

    public List<string> _localEntries = new List<string>();

    // Display Entries
    public void DisplayEntry(Entry e)
    {
        if (e._localEntries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        for (int i = 0; i < e._localEntries.Count; i++)
        {
            string[] parts = e._localEntries[i].Split("~~");
            if (parts.Length == 2)
            {
                Console.WriteLine($"{parts[0]}\n{parts[1]}");
            }
            else
            {
                Console.WriteLine(e._localEntries[i]);
            }
        }
    }

    // Build New Entry
    public void BuildEntry(Prompts p, Entry e)
    {
        // EXTRA: randomly select a prompt from the list and remove that from the list so it's not redundant
        Random rand = new Random();
        if (p._prompt.Count > 0)
        {
            p._randomIndex = rand.Next(p._prompt.Count);
            e._prompt = p._prompt[p._randomIndex];
            p._prompt.RemoveAt(p._randomIndex);

            // Write to display
            Console.WriteLine(e._prompt);
            Console.Write("> ");
            
            // Collect response to Entry class to build entry
            e._response = Console.ReadLine().Trim();
            
            // build entry into class
            e._localEntries.Add($"Date: {e._currentDate.ToString("MM-dd-yyyy")} - Prompt: {e._prompt}~~{e._response}");
            Console.WriteLine("\nEntry added successfully.\n");
        }
        // EXTRA: If no more prompt questions, just inform them there's no more and return to menu
        else
        {
            Console.WriteLine("No more prompt questions.");
        }
    }
}
