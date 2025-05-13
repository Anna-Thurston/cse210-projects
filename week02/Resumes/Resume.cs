using System;

public class Resume
{
    // Member name
    public string _name;

    // List of jobs
    public List<Job> _jobs = new List<Job>();

    // Display resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}