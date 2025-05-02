namespace Sea_Transportation_Management_System.Model.Transportable.Fluids
{
    public class Water : Liquid
    {
        public override string Name => nameof(Water);
        public override double Density => 1.0; // kg/l

        public Water(double volume) : base(volume) { }
    }
}
