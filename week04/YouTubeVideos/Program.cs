using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the videos
        List<Video> videos = new List<Video>();

        // Create Video 1 and its comments
        Video video1 = new Video("Introduction to C# Programming", "TechAcademy", 600);
        video1.AddComment(new Comment("Eliezer vivas ", "This was incredibly helpful, thank you!"));
        video1.AddComment(new Comment("Rocks D. Xebec", "Clear explanations and great pacing."));
        video1.AddComment(new Comment("Chadwick Boseman", "I finally understand classes and objects now."));
        videos.Add(video1);

        // Create Video 2 and its comments
        Video video2 = new Video("Design Patterns in Object-Oriented Design", "DesignCraft", 1200);
        video2.AddComment(new Comment("Ichigo KURUSAKI", "Awesome guide on singleton and factory patterns."));
        video2.AddComment(new Comment("MAYA BISHOU", "Could you do a follow-up video on MVC?"));
        video2.AddComment(new Comment("Castle in the sky", "Very structured, exactly what I needed for my interview prep."));
        videos.Add(video2);

        // Create Video 3 and its comments
        Video video3 = new Video("Database Design & Normalization", "CodeFlow", 950);
        video3.AddComment(new Comment("Minato kamikaze", "Great overview of 1NF, 2NF, and 3NF."));
        video3.AddComment(new Comment("Rimuro Pempest", "Loved the practical examples using SQL."));
        video3.AddComment(new Comment("Ivy QUEEN", "The animations helped me visualize the join operations better."));
        videos.Add(video3);

        // Create Video 4 and its comments (C# Full Course for free)
        Video video4 = new Video("C# Full Course for free", "Bro Code", 14400);
        video4.AddComment(new Comment("Cassandra Alexandra", "This C# course is amazing, everything is explained so clearly."));
        video4.AddComment(new Comment("Cascada", "This 4-hour course is exactly what I needed to get started."));
        video4.AddComment(new Comment("Liam Valfort", "I will find your channel, and I will subscribe."));
        videos.Add(video4);

        // Display the details of each video and its comments
        Console.WriteLine("===============================================================================");
        Console.WriteLine("                         YOUTUBE VIDEO MONITORING SYSTEM                       ");
        Console.WriteLine("===============================================================================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title:       {video.GetTitle()}");
            Console.WriteLine($"Author:      {video.GetAuthor()}");
            Console.WriteLine($"Length:      {video.GetLength()} seconds");
            Console.WriteLine($"Comments:    {video.GetCommentCount()} total comments");
            Console.WriteLine("Comments Feed:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: \"{comment.GetComment()}\"");
            }
            
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}