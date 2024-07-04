using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public void Start()
    {
        ShowStartingMessage();
        PrepareToBegin();
        PerformActivity();
        ShowEndingMessage();
    }

    protected void ShowStartingMessage()
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine("Great job! You have completed the activity.");
        Console.WriteLine($"You spent {Duration} seconds on the {Name} activity.");
        ShowCountdown(3);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    protected abstract void PerformActivity();
}