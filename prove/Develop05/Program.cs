using System;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    goalManager.CreateNewGoal();
                    break;
                case 2:
                    Console.WriteLine("Enter the name of the goal:");
                    string goalName = Console.ReadLine();
                    goalManager.RecordEvent(goalName);
                    break;
                case 3:
                    goalManager.ShowGoals();
                    break;
                case 4:
                    goalManager.ShowScore();
                    break;
                case 5:
                    Console.WriteLine("Enter the file path to save goals:");
                    string savePath = Console.ReadLine();
                    goalManager.SaveGoals(savePath);
                    break;
                case 6:
                    Console.WriteLine("Enter the file path to load goals:");
                    string loadPath = Console.ReadLine();
                    goalManager.LoadGoals(loadPath);
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
