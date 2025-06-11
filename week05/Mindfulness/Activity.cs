using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    public static void LogActivity(string name)
    {
        if (_activityLog.ContainsKey(name))
        {
            _activityLog[name]++;
        }
        else
        {
            _activityLog[name] = 1;
        }
    }

    public static void ShowActivityLog()
    {
        Console.WriteLine("\nActivity Log:");
        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"- {entry.Key}: {entry.Value} time(s)");
        }
    }
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like to do this activity? ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid number of seconds: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
