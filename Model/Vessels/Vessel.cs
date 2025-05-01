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
        get { return Id; }
        protected set
        {
            if (Id < 0)
            {
                MessageBox.Show("Id cannot be negative!");
                return;
            }
        }
    }
    public double Capacity
    {
        get { return Capacity; }
        protected set
        {
            if (Capacity <= 0)
            {
                MessageBox.Show("Capacity must be greater than zero!");
                return;
            }
        }
    }
    public float Fuel { get; protected set; }
    public float FuelCapacity
    {
        get { return FuelCapacity; }
        protected set
        {
            if (FuelCapacity < 50)
            {
                MessageBox.Show("Fuel capacity must be at least 50!");
                return;
            }
        }
    }

    public abstract double CalculateFuelConsumption(double distance); // в різних типах суден різні витрати в залежності від типу та вантажу

    public void Refuel(float amount)
    {
        Fuel = Fuel + amount > FuelCapacity ? FuelCapacity : Fuel + amount;
    }
}
