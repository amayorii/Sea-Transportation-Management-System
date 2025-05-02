using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Transportable;
using Sea_Transportation_Management_System.Model.Transportable.Fluids;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Container container = new Container(4, "containerWithSand", 50);
        container.Add("nigger");
        container.Add("sausage");
        container.Add("box");
        container.Add("sofa");
        ContainerShip c1 = new ContainerShip(1, "Sea Queen", 250, 320);
        c1.LoadCargo(container);
        Tanker t1 = new Tanker(2, "Red Serpent", 1500, 600);
        t1.LoadCargo(new Barrel(4, new Water(500)));
        Port port = new Port(1, "Black Pearl", new Point(-5167, 8762), 700);
        Port port2 = new Port(2, "Red Pearl", new Point(-53, 422), 530.5f);
        Voyage voyage = new Voyage(1, t1, port, port2, new DateTime(2025, 05, 02, 20, 52, 06), new DateTime(2025, 05, 02, 20, 55, 06));
        MessageBox.Show(t1.CalculateFuelConsumption(voyage.Distance).ToString());
        port.RefuelVessel(c1, 250);
        // do table and automatic id setting
        // make more transportable things (fluids, passengers)
    }
}