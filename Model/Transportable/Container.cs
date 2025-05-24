using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Transportable
{
    public class Container : ITransportable
    {
        public int Id { get; }
        public double Weight { get; }
        public string ContainerSign { get; }

        public ObservableCollection<string> Contents { get; }

        public Container(int id, string containerSign, double weight)
        {
            Id = id;
            ContainerSign = containerSign ?? throw new ArgumentNullException(nameof(containerSign));
            Weight = weight;
            Contents = new ObservableCollection<string>();
        }
        public void AddContent(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
                Contents.Add(item);
        }

        public void RemoveContent(string item)
        {
            Contents.Remove(item);
        }

        public override string ToString()
        {
            string contents = Contents.Count > 0 ? string.Join(", ", Contents) : "Empty";
            return $"#{Id} [{ContainerSign}] Weight: {Weight} tons, Contents: {contents}";
        }
    }
}
