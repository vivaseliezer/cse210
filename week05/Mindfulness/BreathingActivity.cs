using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            ShowBreathingAnimation(true, 4);
            ShowBreathingAnimation(false, 6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void ShowBreathingAnimation(bool inhale, int seconds)
    {
        int totalMs = seconds * 1000;
        int intervalMs = 100;
        int steps = totalMs / intervalMs;

        for (int step = 1; step <= steps; step++)
        {
            double progressRatio = (double)step / steps;
            double curveRatio;

            if (inhale)
            {
                // Inhale: grows quickly at first, then slows down near the end
                curveRatio = Math.Sin(progressRatio * Math.PI / 2);
            }
            else
            {
                // Exhale: shrinks quickly at first, then slows down near the end
                curveRatio = 1.0 - Math.Sin(progressRatio * Math.PI / 2);
            }

            int maxBarLength = 20;
            int currentLength = (int)(curveRatio * maxBarLength);

            string bar = new string('o', currentLength);
            string spaces = new string(' ', maxBarLength - currentLength);
            string action = inhale ? "Breathe in... " : "Breathe out...";
            
            double remainingSeconds = (double)(totalMs - (step * intervalMs)) / 1000.0;
            int displaySeconds = (int)Math.Ceiling(remainingSeconds);

            Console.Write($"\r{action} [{bar}{spaces}] {displaySeconds} ");
            
            Thread.Sleep(intervalMs);
        }
        Console.WriteLine();
    }
}
