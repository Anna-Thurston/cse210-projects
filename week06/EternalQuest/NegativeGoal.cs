public class NegativeGoal : Goal
{
    private int _penalty;

    public NegativeGoal(string shortName, string description, int penalty)
        : base(shortName, description, -penalty)
    {
        _penalty = penalty;
    }

    public override int RecordEvent()
    {
        return -_penalty;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Lose {_penalty} points when recorded.";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_penalty}";
    }

    public static NegativeGoal FromString(string data)
    {
        string[] parts = data.Split(',');
        return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
    }
}
