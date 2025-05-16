using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using MapControl;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Vessel> Vessels { get; set; } = new ObservableCollection<Vessel>();
    public ObservableCollection<Port> Ports { get; set; } = new ObservableCollection<Port>();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        map.SizeChanged += (s, e) =>
        {
            var clip = new RectangleGeometry
            {
                Rect = new Rect(0, 0, map.ActualWidth, map.ActualHeight),
                RadiusX = 8.5,
                RadiusY = 8.5
            };
            map.Clip = clip;
        };
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ContainerShip c1 = new ContainerShip(1, "Sea Queen", 250, 320);
        c1.Location = new Location(46.4825, 30.7233);
        Tanker t1 = new Tanker(2, "Red Serpent", 1500, 600);
        t1.Location = new Location(32.4144, 5.6555);
        c1.Refuel(500);

        Vessels.Add(c1); // Odessa
        Vessels.Add(t1); // Sevastopol (Hypothetical)

        Port port = new Port(1, "Black Pearl", new Location(44.6500, 33.5200), 700);
        Ports.Add(port);

        vesselsList.ItemsSource = Vessels;
    }
}