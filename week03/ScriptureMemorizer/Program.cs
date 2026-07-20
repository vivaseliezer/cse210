using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filename = "scriptures.txt";

        // Check if the scriptures file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: The file '{filename}' was not found.");
            return;
        }

        // Read all non-empty lines from the file
        List<string> lines = File.ReadAllLines(filename)
                                 .Where(line => !string.IsNullOrWhiteSpace(line))
                                 .ToList();

        if (lines.Count == 0)
        {
            Console.WriteLine("Error: The scriptures file is empty.");
            return;
        }

        // Randomly select one scripture line
        Random random = new Random();
        int randomIndex = random.Next(lines.Count);
        string selectedLine = lines[randomIndex];

        // Parse reference and verses text (split by ~~)
        string[] parts = selectedLine.Split(new string[] { "~~" }, StringSplitOptions.None);
        if (parts.Length < 2)
        {
            Console.WriteLine("Error: Invalid scripture format in file.");
            return;
        }

        string referenceString = parts[0];
        // Join subsequent parts with a newline to separate multiple verses nicely
        string scriptureText = string.Join("\n", parts.Skip(1));

        // Create reference and scripture instances
        Reference reference = new Reference(referenceString);
        Scripture scripture = new Scripture(reference, scriptureText);

        string userEntry = "";

        // Main game loop
        while (!scripture.IsCompletelyHidden() && userEntry.ToLower() != "quit")
        {
            ClearConsole();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("  + Press Enter to hide more words");
            Console.WriteLine("  + Press Space and Enter to temporarily show hidden words");
            Console.WriteLine("  + Type 'quit' to exit");
            Console.WriteLine("----------------------------------------------------");
            Console.Write("> ");

            userEntry = Console.ReadLine();

            if (userEntry == " ")
            {
                scripture.TempShowAll();
            }
            else
            {
                scripture.ClearTempShowAll();
                scripture.HideRandomWords(3);
            }
        }

        // One final clear and display of the end state
        ClearConsole();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nGood job memorizing! Program finished.\n");
    }

    static void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // Ignored when console output is redirected or handle is invalid
        }
    }
}