using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void Run()
    {
        LogActivity(_name);
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Follow the prompts below as you breathe in and out.\n");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.Write("\nBreathe out...");
            ShowCountdown(6);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }
}
