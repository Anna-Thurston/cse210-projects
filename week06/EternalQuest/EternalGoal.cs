public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }

    public static EternalGoal FromString(string data)
    {
        string[] parts = data.Split(',');
        return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
    }
}
