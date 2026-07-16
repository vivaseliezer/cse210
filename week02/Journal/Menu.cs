using System;
using System.Collections.Generic;

public class Menu
{
    // Menu Items
    string _option1 = "1. Write";
    string _option2 = "2. Display";
    string _option3 = "3. Load";
    string _option4 = "4. Save";
    string _option5 = "5. Quit";

    // Valid input options
    List<int> _validOptions = new List<int> { 1, 2, 3, 4, 5 };

    // User Selection default to 0
    public int _menuOption = 0;

    // Save the menu options into a list to be called and displayed
    public List<string> menu = new List<string>();

    public Menu()
    {
        menu.Add(_option1);
        menu.Add(_option2);
        menu.Add(_option3);
        menu.Add(_option4);
        menu.Add(_option5);
    }

    // DisplayMenu Function
    public void DisplayMenu()
    {
        Boolean isValid = false;
        while (!isValid)
        {
            Console.WriteLine();
            // Loop through menu and print each line to the display
            foreach (string menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
            Console.Write("> ");

            // Collect user input with validation
            string input = Console.ReadLine();
            if (int.TryParse(input, out _menuOption))
            {
                isValid = _validOptions.Contains(_menuOption);
            }
            else
            {
                isValid = false;
            }

            // If still not valid, notify them and then it will loop the menu again
            if (!isValid)
            {
                Console.WriteLine();
                Console.WriteLine($"{input} is an invalid option. Try again. ");
            }
        }
    }
}
