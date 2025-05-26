using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
    }

    public string GetEntryText()
    {
        return "Date: " + _date + "\nPrompt: " + _prompt + "\nResponse: " + _response + "\n";
    }

    public string ToFileLine()
    {
        return _date + "|" + _prompt + "|" + _response;
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('|');
        Entry entry = new Entry(parts[1], parts[2]);
        entry._date = parts[0];
        return entry;
    }
}
