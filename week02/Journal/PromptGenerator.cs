using System;

public class PromptGenerator
{
    private string[] _prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private Random _rand = new Random();

    public string GetPrompt()
    {
        int index = _rand.Next(0, _prompts.Length);
        return _prompts[index];
    }
}
