using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter the short name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("Enter the target number of times: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            case "4":
                Console.Write("Enter the target amount: ");
                int progressTarget = int.Parse(Console.ReadLine());

                Console.Write("Enter the points per unit: ");
                int pointsPerUnit = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus on completion: ");
                int progressBonus = int.Parse(Console.ReadLine());

                _goals.Add(new ProgressGoal(name, description, pointsPerUnit, progressTarget, progressBonus));
                break;

            case "5":
                Console.Write("Enter the penalty (points to lose): ");
                int penalty = int.Parse(Console.ReadLine());

                _goals.Add(new NegativeGoal(name, description, penalty));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        index -= 1;

        int earned;
        if (_goals[index] is ProgressGoal pg)
        {
            Console.Write("How much progress did you make? ");
            if (!int.TryParse(Console.ReadLine(), out int units) || units < 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            earned = pg.AddProgress(units);
        }
        else
        {
            earned = _goals[index].RecordEvent();
        }

        _score += earned;
        Console.WriteLine($"Congratulations! You earned {earned} points!");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                if (parts.Length < 2)
                {
                    Console.WriteLine($"Invalid format on line {i + 1}");
                    continue;
                }

                string type = parts[0];
                string data = parts[1];

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(SimpleGoal.FromString(data));
                        break;
                    case "EternalGoal":
                        _goals.Add(EternalGoal.FromString(data));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(ChecklistGoal.FromString(data));
                        break;
                    case "ProgressGoal":
                        _goals.Add(ProgressGoal.FromString(data));
                        break;
                    case "NegativeGoal":
                        _goals.Add(NegativeGoal.FromString(data));
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {type}");
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully.");
            Console.WriteLine($"Current score: {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    public int GetScore()
    {
        return _score;
    }
}
