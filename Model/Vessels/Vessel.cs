using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MapControl;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Vessels;

public enum VesselStatus
{
    Unknown,
    WaitingInPort,
    OnVoyage
}
public abstract class Vessel : IRefuelable, INotifyPropertyChanged
{
    private int _id;
    private string _name;
    private Location _location;
    private float _fuel;
    private VesselStatus _status;
    private float _fuelCapacity;
    private Port? _currentPort;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Port? CurrentPort
    {
        get { return _currentPort; }
        protected set
        {
            _currentPort = value;
            OnPropertyChanged(nameof(CurrentPort));
        }
    }
    public Location Location
    {
        get { return _location; }
        protected set
        {
            _location = value;
            OnPropertyChanged(nameof(Location));
        }
    }
    public Vessel(int id, string name, Port currentPort, float fuelCapacity)
    {
        Random rnd = new Random();
        Name = name;
        Id = id;
        FuelCapacity = fuelCapacity;
        CurrentPort = currentPort;
        Location = new Location(CurrentPort.Location.Latitude + ((rnd.NextDouble() - rnd.NextDouble()) * 0.001), CurrentPort.Location.Longitude + ((rnd.NextDouble() - rnd.NextDouble()) * 0.001));
    }
    public string Name
    {
        get { return _name; }
        protected set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public VesselStatus Status
    {
        get { return _status; }
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public int Id
    {
        get { return _id; }
        protected set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public float Fuel
    {
        get { return _fuel; }
        protected set
        {
            _fuel = value;
            OnPropertyChanged(nameof(Fuel));
        }
    }
    public float FuelCapacity
    {
        get { return _fuelCapacity; }
        protected set
        {
            if (value < 50)
            {
                MessageBox.Show("Fuel capacity must be at least 50!");
                return;
            }
            _fuelCapacity = value;
            OnPropertyChanged(nameof(FuelCapacity));
        }
    }
    public string Info => ToString();
    protected void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
    }
    public abstract double CalculateFuelConsumption(double distance); // в різних типах суден різні витрати в залежності від типу та вантажу
    public void UpdateStatus(ObservableCollection<Port> ports, double detectionRadiusNauticalMiles = 1.2)
    {
        foreach (var port in ports)
        {
            if (GeoLocator.IsWithinRadius(Location, port.Location, detectionRadiusNauticalMiles))
            {
                CurrentPort = port;
                port.VesselsInPort.Add(this);
                Status = VesselStatus.WaitingInPort;
                return;
            }
            port.VesselsInPort.Remove(this);
        }

        CurrentPort = null!;
        Status = VesselStatus.OnVoyage;
    }
    public void Refuel(float amount)
    {
        if (amount < 0)
        {
            MessageBox.Show("Cannot refuel for a negative value!");
            return;
        }
        Fuel = Fuel + amount > FuelCapacity ? FuelCapacity : Fuel + amount;
    }

    public override string ToString()
    {
        return $"Id: {Id}\n{"Name:",-7}{Name.Length switch
        {
            > 15 => $"{Name}\t",
            < 3 => $"{Name,-20}\t\t",
            _ => $"{Name,-10}\t\t"
        }}{"Fuel: ",-7}{Fuel}/{FuelCapacity}\n{"Type: ",-10}{GetType().Name,-10}\n{"Status: ",-10}{Status}";
    }
}
