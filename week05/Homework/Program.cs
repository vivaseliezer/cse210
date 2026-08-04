using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a base Assignment object
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        // 2. Create a MathAssignment object
        MathAssignment assignment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        // 3. Create a WritingAssignment object
        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The Civil War");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}