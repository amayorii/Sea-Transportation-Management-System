using System.Collections.ObjectModel;
using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public ObservableCollection<Vessel> Vessels { get; set; } = new ObservableCollection<Vessel>();
    public ObservableCollection<Port> Ports { get; set; } = new ObservableCollection<Port>();
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(Vessels, Ports)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}

