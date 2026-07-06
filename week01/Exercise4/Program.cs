using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out userNumber))
            {
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        if (numbers.Count > 0)
        {
            // Core requirements
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge 1: Smallest positive number
            int? smallestPositive = null;
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    if (smallestPositive == null || num < smallestPositive)
                    {
                        smallestPositive = num;
                    }
                }
            }

            if (smallestPositive != null)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch Challenge 2: Sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}