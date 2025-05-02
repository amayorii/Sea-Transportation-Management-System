using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Transportable
{
    public class Container : List<string>, ITransportable
    {
        public readonly int Id;
        public readonly double Weight;
        public readonly string ContainerSign;
        public Container(int id, string containerSign, double weight)
        {
            Id = id;
            Weight = weight;
            ContainerSign = containerSign;
        }
        public override string ToString()
        {
            string contents = Count > 0 ? string.Join(", ", this) : "Empty";
            return $"#{Id} [{ContainerSign}] Weight: {Weight} tons, Contents: {contents}";
        }

    }
}
