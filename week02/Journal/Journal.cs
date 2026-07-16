using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public string _filename = "";

    // LoadFromFile
    public void LoadFromFile(Entry e)
    {
        GetFileName();

        // EXTRA - check if filename exists first.  
        if (File.Exists(_filename))
        {
            Console.WriteLine("\nLoading File");
            string[] lines = System.IO.File.ReadAllLines(_filename);
            e._localEntries.Clear(); // Clear current list before loading new ones
            foreach (string line in lines)
            {
                e._localEntries.Add(line);
            }
            Console.WriteLine($"Successfully loaded {lines.Length} entries.\n");
        }
        else
        {
            Console.WriteLine($"\n{_filename} doesn't exist.\n");
        }
    }

    // SaveToFile
    public void SaveToFile(Entry e)
    {
        GetFileName();
        Console.WriteLine("Saving File");
        
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            for (int i = 0; i < e._localEntries.Count; i++)
            {
                outputFile.WriteLine(e._localEntries[i]);
            }
        }
        Console.WriteLine($"Successfully saved entries to {_filename}.\n");
    }

    // Get Filename Method
    public string GetFileName()
    {
        Console.WriteLine("What is the filename?");
        _filename = Console.ReadLine().Trim();
        return _filename;
    }
}
