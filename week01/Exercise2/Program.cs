using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int percent))
        {
            string letter = "";
            if (percent >= 90)
            {
                letter = "A";
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Stretch Challenge: Add sign (+ or -)
            string sign = "";
            int lastDigit = percent % 10;

            if (letter != "F")
            {
                if (lastDigit >= 7)
                {
                    // No A+ grade
                    if (letter != "A")
                    {
                        sign = "+";
                    }
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            Console.WriteLine($"Your letter grade is: {letter}{sign}");

            if (percent >= 70)
            {
                Console.WriteLine("Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine("Don't give up! You can do better next time.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid integer for the grade percentage.");
        }
    }
}