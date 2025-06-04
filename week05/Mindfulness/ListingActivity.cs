using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration, List<string> prompts)
        : base(name, description, duration)
    {
        _prompts = prompts;
        _count = 0;
    }

    public void Run() { }

    public string GetRandomPrompt()
    {
        return "";
    }

    public List<string> GetResponseList()
    {
        return new List<string>();
    }
}
