using System.Windows;
using Sea_Transportation_Management_System.Model.Transportable;
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
        Container container = new Container("containerWithSand", 50);
        container.Add("nigger");
        container.Add("sausage");
        container.Add("box");
        container.Add("sofa");
        ContainerShip c1 = new ContainerShip(1, "Sea Queen", 250, 60);
        c1.LoadCargo(container);
        c1.ViewCargo();
        // do table and automatic id setting
        // make more transportable things (fluids, passengers)
    }
}