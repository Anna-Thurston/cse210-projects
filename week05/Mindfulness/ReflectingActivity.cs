using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _questions;
    private List<string> _prompts;

    public ReflectingActivity(string name, string description, int duration, List<string> prompts, List<string> questions)
        : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run() { }

    public string GetRandomPrompt()
    {
        return "";
    }

    public string GetRandomQuestion()
    {
        return "";
    }

    public void DisplayPrompt() { }

    public void DisplayQuestions() { }
}
