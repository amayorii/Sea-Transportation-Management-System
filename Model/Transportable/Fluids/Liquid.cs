public abstract class Liquid
{
    public abstract string Name { get; }
    public abstract double Density { get; } // kg/l
    public double Volume { get; } // l

    public double Weight => Volume * Density; // kg

    protected Liquid(double volume)
    {
        if (volume <= 0)
            throw new ArgumentException("Volume must be positive.");
        Volume = volume;
    }

    public override string ToString() => $"{Name} ({Volume}L, {Density}kg/L)";
}
