using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _responses;

    public ListingActivity(string name, string description, List<string> prompts)
        : base(name, description)
    {
        _prompts = prompts;
        _responses = new List<string>();
    }

    public void Run()
    {
        LogActivity(_name);
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Console.WriteLine("Start listing your items. Press Enter after each one:");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }

        Console.WriteLine($"\nYou listed {_responses.Count} item(s)!");
        ShowSpinner(3);
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
