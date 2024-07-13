using System;

abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; private set; }
    public bool IsCompleted { get; internal set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent(ref int totalPoints);

    public override string ToString()
    {
        return $"{Name} - {Points} points";
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent(ref int totalPoints)
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            totalPoints += Points;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {(IsCompleted ? "[X]" : "[ ]")}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent(ref int totalPoints)
    {
        totalPoints += Points;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - [∞]";
    }
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; internal set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent(ref int totalPoints)
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            totalPoints += Points;
            if (CurrentCount >= TargetCount)
            {
                IsCompleted = true;
                totalPoints += BonusPoints;
            }
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Completed {CurrentCount}/{TargetCount} times - {(IsCompleted ? "[X]" : "[ ]")}";
    }
}