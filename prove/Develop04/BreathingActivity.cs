public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            elapsedTime += 4;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            elapsedTime += 4;
        }
    }
}