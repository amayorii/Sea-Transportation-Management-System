using Sea_Transportation_Management_System.Model.Interfaces;

public class Barrel : ITransportable
{
    public readonly int Id;
    public readonly Liquid Liquid;
    public Barrel(int id, Liquid _liquid)
    {
        Id = id;
        Liquid = _liquid ?? throw new ArgumentNullException(nameof(_liquid));
    }

    public double Weight => Liquid.Weight;

    public override string ToString() => $"Barrel \"{Id}\" - {Liquid.Name}, Volume: {Liquid.Volume}L, Weight: {Weight}kg";
}
