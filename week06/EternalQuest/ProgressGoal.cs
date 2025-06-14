using System;

public class ProgressGoal : Goal
{
    private int _targetProgress;
    private int _currentProgress;
    private int _pointsPerUnit;
    private int _bonus;

    public ProgressGoal(string shortName, string description, int pointsPerUnit, int targetProgress, int bonus)
        : base(shortName, description, pointsPerUnit)
    {
        _targetProgress = targetProgress;
        _pointsPerUnit = pointsPerUnit;
        _bonus = bonus;
        _currentProgress = 0;
    }

    // Deprecated: Handled externally via AddProgress() to decouple from user input
    public override int RecordEvent()
    {
        return 0;
    }

    // New method to process progress updates from GoalManager
    public int AddProgress(int units)
    {
        _currentProgress += units;
        int earned = units * _pointsPerUnit;

        if (_currentProgress >= _targetProgress && !IsComplete())
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _targetProgress;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Progress: {_currentProgress}/{_targetProgress}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName},{_description},{_pointsPerUnit},{_targetProgress},{_bonus},{_currentProgress}";
    }

    public static ProgressGoal FromString(string data)
    {
        string[] parts = data.Split(',');
        var goal = new ProgressGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
        goal._currentProgress = int.Parse(parts[5]);
        return goal;
    }
}
