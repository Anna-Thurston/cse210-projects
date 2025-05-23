using System;

class Program
{
    static void Main(string[] args)
    {
// First job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

// Second Job
        Job job2 = new Job();
        job2._jobTitle = "Senior Developer";
        job2._company = "Google";
        job2._startYear = 2022;
        job2._endYear = 2025;

// Create new instance of Resume object
        Resume myResume = new Resume();
        myResume._name = "Anna Thurston";

// Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

// Display resume
        myResume.Display();
    }
}