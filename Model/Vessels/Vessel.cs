using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Vessels;

public enum VesselStatus
{
    Unknown,
    WaitingInPort,
    OnVoyage
}
public abstract class Vessel : IRefuelable
{
    private int _id;
    private double _capacity;
    private float _fuelCapacity;
    public Vessel(int id, string? name, double cargoCapacity, float fuelCapacity)
    {
        Name = name;
        Id = id;
        Capacity = cargoCapacity;
        FuelCapacity = fuelCapacity;
    }
    public string? Name { get; protected set; }
    public VesselStatus Status { get; set; }

    public int Id
    {
        get { return _id; }
        protected set
        {
            _id = value;
        }
    }
    public double Capacity
    {
        get { return _capacity; }
        protected set
        {
            if (value <= 0)
            {
                MessageBox.Show("Capacity must be greater than zero!");
                return;
            }
            _capacity = value;
        }
    }
    public float Fuel { get; protected set; }
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
        }
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
}
