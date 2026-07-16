using System;
using System.Collections.Generic;

// Represents a person's resume containing their name and list of jobs
public class Resume
{
    // Member variables
    public string _name;
    // Initializing the list to avoid null reference exceptions
    public List<Job> _jobs = new List<Job>();

    // Method to display the entire resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate through each job in the list and display it
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
