using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime Date => date;
    public int Minutes => minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / Minutes) * 60;

    public override double GetPace() => Minutes / distance;
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * Minutes) / 60;

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed;
}

public class Swimming : Activity
{
    private int laps;
    private const double LapDistanceKm = 50.0 / 1000.0;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * LapDistanceKm;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 30, 20),
            new Swimming(new DateTime(2022, 11, 3), 30, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
