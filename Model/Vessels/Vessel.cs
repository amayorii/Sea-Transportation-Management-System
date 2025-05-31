using System.ComponentModel;
using System.Windows;
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
    private Port _currentPort;
    private float _fuel;
    private VesselStatus _status;
    private float _fuelCapacity;
    protected Type _typeOfTransportable = null;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Vessel(int id, string name, float fuelCapacity, Port currentPort)
    {
        Name = name;
        Id = id;
        FuelCapacity = fuelCapacity;
        CurrentPort = currentPort;
        currentPort.AttachVessel(this);
        Location = CurrentPort.Location;
        Status = VesselStatus.WaitingInPort;
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

    public Type TypeOfTransportable
    {
        get { return _typeOfTransportable; }
    }

    public Location Location
    {
        get { return _location; }
        set
        {
            _location = value;
            OnPropertyChanged(nameof(Location));
        }
    }

    public Port CurrentPort
    {
        get { return _currentPort; }
        set
        {
            _currentPort = value;
            OnPropertyChanged(nameof(CurrentPort));
        }
    }
    public string Info => ToString();
    protected void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
    }
    public abstract double CalculateFuelConsumption(double distance); // в різних типах суден різні витрати в залежності від типу та вантажу

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
