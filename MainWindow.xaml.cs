using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.View;

namespace Sea_Transportation_Management_System;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void VesselsBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        vesselsBtn.IsEnabled = false;
        portsBtn.IsEnabled = true;

        vesselsList.Visibility = Visibility.Visible;
        portsList.Visibility = Visibility.Hidden;

        vesselPanel.Visibility = Visibility.Visible;
        portPanel.Visibility = Visibility.Hidden;
    }

    private void PortsBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        portsBtn.IsEnabled = false;
        vesselsBtn.IsEnabled = true;

        portsList.Visibility = Visibility.Visible;
        vesselsList.Visibility = Visibility.Hidden;

        portPanel.Visibility = Visibility.Visible;
        vesselPanel.Visibility = Visibility.Hidden;
    }

    private void RegisterVessel(object sender, RoutedEventArgs e)
    {
        RegisterVesselWindow regVessel = new RegisterVesselWindow();
        regVessel.ShowDialog();
    }

    private void RegisterPort(object sender, RoutedEventArgs e)
    {
        RegisterPortWindow registerPort = new RegisterPortWindow();
        registerPort.ShowDialog();
    }

    private void RefuelClick(object sender, RoutedEventArgs e)
    {
        RefuelWindow refuelWindow = null;

        if (vesselRefuel.IsEnabled && !vesselsBtn.IsEnabled)
            refuelWindow = new RefuelWindow(vesselsList.SelectedItem as Vessel);
        else if (portRefuel.IsEnabled && !portsBtn.IsEnabled)
            refuelWindow = new RefuelWindow(portsList.SelectedItem as Port);

        refuelWindow?.ShowDialog();
    }

    private void ViewCargoClick(object sender, RoutedEventArgs e)
    {
        ViewStorageWindow viewStorageWindow = new ViewStorageWindow(new object());
        viewStorageWindow.ShowDialog();
    }

    private void PlanAVoyageClick(object sender, RoutedEventArgs e)
    {
        VoyagePlanningWindow voyagePlanningWindow = new VoyagePlanningWindow();
        voyagePlanningWindow.ShowDialog();
    }

    private void VesselsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        vesselRefuel.IsEnabled = vesselsList.SelectedItem != null;
        deleteVesselBtn.IsEnabled = vesselsList.SelectedItem != null;
        viewCargoBtn.IsEnabled = vesselsList.SelectedItem != null;
    }

    private void PortsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        portRefuel.IsEnabled = portsList.SelectedItem != null;
        deletePortBtn.IsEnabled = portsList.SelectedItem != null;
        viewWarehouseBtn.IsEnabled = portsList.SelectedItem != null;
    }
}