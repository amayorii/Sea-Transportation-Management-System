namespace Sea_Transportation_Management_System.Model.Transportable.Fluids
{
    public class Oil : Liquid
    {
        public override string Name => nameof(Oil);
        public override double Density => 0.825; // kg/l

        public Oil(double volume) : base(volume) { }
    }
}
