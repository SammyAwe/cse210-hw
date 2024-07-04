using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have a few seconds to prepare to start listing...");
        ShowCountdown(3);

        Console.WriteLine("Start listing items:");

        int elapsedTime = 0;
        int itemCount = 0;
        while (elapsedTime < Duration)
        {
            Console.Write("Item: ");
            Console.ReadLine();
            itemCount++;
            elapsedTime += 5;
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }
}
