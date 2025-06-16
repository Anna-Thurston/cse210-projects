public class Running : Activity
{
    private double _distanceKm;

    public Running(string date, int minutes, double distanceKm)
        : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;
    public override double GetSpeed() => (_distanceKm / LengthMinutes) * 60;
    public override double GetPace() => LengthMinutes / _distanceKm;
}
