namespace Sea_Transportation_Management_System.Model.Transportable.Fluids
{
    public class Fuel : Liquid
    {
        public override string Name => nameof(Fuel);
        public override double Density => 0.8; // kg/l

        public Fuel(double volume) : base(volume) { }
    }
}
