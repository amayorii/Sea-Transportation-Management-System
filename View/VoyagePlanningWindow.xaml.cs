using System.Collections.ObjectModel;
using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for VoyagePlanningWindow.xaml
    /// </summary>
    public partial class VoyagePlanningWindow : Window
    {
        private readonly ObservableCollection<Voyage> voyages = App.Voyages;
        private Port _toPort;
        private Vessel _vessel;
        public VoyagePlanningWindow()
        {
            InitializeComponent();
            DataContext = new VoyagePlanningViewModel();
        }

        private void ToSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _toPort = App.Ports.Where(port => port.Name == toPortBox.SelectedItem.ToString()).Select(port => port).First();
            Analyse();
        }

        private void Analyse()
        {
            if (toPortBox.SelectedItem != null && vesselBox.SelectedItem != null)
            {
                distanceDisplay.Text = _vessel.CurrentPort.CalculateDistanceTo(_toPort).ToString("F2");
                fuelConsumptionDisplay.Text = _vessel.CalculateFuelConsumption(Convert.ToDouble(distanceDisplay.Text)).ToString("F0");
            }
        }

        private void VesselSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _vessel = App.Vessels.Where(vessel => vessel.Name == vesselBox.SelectedItem.ToString()).Select(vessel => vessel).First();
            toPortBox.IsEnabled = true;
            if (toPortBox.SelectedItem != null)
                Analyse();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = voyages.Count == 0 ? 1 : voyages.Last().Id + 1;
                string name = nameBox.Text;
                DateTime departure = depDate.SelectedDate.Value;
                DateTime arrival = arrDate.SelectedDate.Value;

                voyages.Add(new Voyage(id, name, _vessel, _vessel.CurrentPort, _toPort, departure, arrival));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
