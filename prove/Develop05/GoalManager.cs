using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent(ref totalPoints);
        }
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {totalPoints}");
    }

    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.IsCompleted}|{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}");
                }
                else
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.IsCompleted}");
                }
            }
        }
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                totalPoints = int.Parse(reader.ReadLine());
                goals.Clear();
                while (!reader.EndOfStream)
                {
                    string[] goalData = reader.ReadLine().Split('|');
                    Goal goal = null;
                    if (goalData[0] == nameof(SimpleGoal))
                    {
                        goal = new SimpleGoal(goalData[1], int.Parse(goalData[2]));
                    }
                    else if (goalData[0] == nameof(EternalGoal))
                    {
                        goal = new EternalGoal(goalData[1], int.Parse(goalData[2]));
                    }
                    else if (goalData[0] == nameof(ChecklistGoal))
                    {
                        goal = new ChecklistGoal(goalData[1], int.Parse(goalData[2]), int.Parse(goalData[5]), int.Parse(goalData[6]))
                        {
                            CurrentCount = int.Parse(goalData[4])
                        };
                    }
                    if (goal != null)
                    {
                        goal.IsCompleted = bool.Parse(goalData[3]);
                        goals.Add(goal);
                    }
                }
            }
        }
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("Enter the type of goal (simple/eternal/checklist):");
        string type = Console.ReadLine().ToLower();
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the points for the goal:");
        int points = int.Parse(Console.ReadLine());

        if (type == "simple")
        {
            AddGoal(new SimpleGoal(name, points));
        }
        else if (type == "eternal")
        {
            AddGoal(new EternalGoal(name, points));
        }
        else if (type == "checklist")
        {
            Console.WriteLine("Enter the target count for the checklist goal:");
            int targetCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the bonus points for completing the checklist goal:");
            int bonusPoints = int.Parse(Console.ReadLine());
            AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
        }
    }
}
