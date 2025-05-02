using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Transportable
{
    public class Container : List<string>, ITransportable
    {
        public readonly double Weight;
        public readonly string ContainerSign;
        public Container(string containerSign, double weight)
        {
            Weight = weight;
            ContainerSign = containerSign;
        }
        public override string ToString()
        {
            string contents = Count > 0 ? string.Join(", ", this) : "Empty";
            return $"[{ContainerSign}] Weight: {Weight} tons, Contents: {contents}";
        }

    }
}
