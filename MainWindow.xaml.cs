using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.View;
using Sea_Transportation_Management_System.ViewModel;

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
        if ((vesselsList.SelectedItem as Vessel).Status == VesselStatus.OnVoyage)
        {
            MessageBox.Show("Vessel must be in port for refueling");
            return;
        }
        RefuelWindow refuelWindow = null;

        if (vesselRefuel.IsEnabled && !vesselsBtn.IsEnabled)
            refuelWindow = new RefuelWindow(vesselsList.SelectedItem as Vessel);
        else if (portRefuel.IsEnabled && !portsBtn.IsEnabled)
            refuelWindow = new RefuelWindow(portsList.SelectedItem as Port);

        refuelWindow?.ShowDialog();
    }

    private void ViewCargoClick(object sender, RoutedEventArgs e)
    {
        ViewStorageWindow viewStorageWindow = null;
        if (viewCargoBtn.IsEnabled && !vesselsBtn.IsEnabled)
            viewStorageWindow = new ViewStorageWindow(vesselsList.SelectedItem as ICargo);
        else if (viewWarehouseBtn.IsEnabled && !portsBtn.IsEnabled)
            viewStorageWindow = new ViewStorageWindow(portsList.SelectedItem as IStoragable);

        viewStorageWindow?.ShowDialog();
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
        viewCargoBtn.IsEnabled = vesselsList.SelectedItem != null && vesselsList.SelectedItem is ICargo;
    }

    private void PortsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        portRefuel.IsEnabled = portsList.SelectedItem != null;
        deletePortBtn.IsEnabled = portsList.SelectedItem != null;
        viewWarehouseBtn.IsEnabled = portsList.SelectedItem != null;
    }

    private void DeleteVessel(object sender, RoutedEventArgs e)
    {
        Vessel vessel = vesselsList.SelectedItem as Vessel;
        if (vessel.Status != VesselStatus.WaitingInPort)
            MessageBox.Show("Vessel must first be in port!");
        else
        {
            if (vessel is ICargo)
            {
                if ((vessel as ICargo).Storage.CurrentItemCount != 0)
                {
                    MessageBox.Show("First you need to unload the vessel!");
                    return;
                }
            }
            if (MessageBox.Show("Are you sure?", "Deregister vessel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                vessel.CurrentPort.DetachVessel(vessel);
                (DataContext as MainViewModel).Vessels.Remove(vessel);
            }
        }
    }

    private void DeletePort(object sender, RoutedEventArgs e)
    {
        Port port = portsList.SelectedItem as Port;
        if (port.Storage.CurrentItemCount != 0)
            MessageBox.Show("First you need to unload the port!");
        else
        {
            if (MessageBox.Show("Are you sure?", "Deregister port", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var vessel in port.VesselsInPort.ToList())
                {
                    port.DetachVessel(vessel);
                    vessel.Status = VesselStatus.Unknown;
                }
                (DataContext as MainViewModel).Ports.Remove(port);
            }
        }
    }
}