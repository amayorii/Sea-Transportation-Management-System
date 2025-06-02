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
        private Port _fromPort;
        private Port _toPort;
        private Vessel _vessel;
        public VoyagePlanningWindow()
        {
            InitializeComponent();
            DataContext = new VoyagePlanningViewModel();
        }

        private void FromSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _fromPort = App.Ports.Where(port => port.Name == fromPortBox.SelectedItem.ToString()).Select(port => port).First();
            CheckIfCanCalculate();
        }

        private void ToSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _toPort = App.Ports.Where(port => port.Name == toPortBox.SelectedItem.ToString()).Select(port => port).First();
            CheckIfCanCalculate();
        }

        private void CheckIfCanCalculate()
        {
            if (fromPortBox.SelectedItem != null && toPortBox.SelectedItem != null && vesselBox.SelectedItem != null)
            {
                distanceDisplay.Text = _fromPort.CalculateDistanceTo(_toPort).ToString();
                fuelConsumptionDisplay.Text = _vessel.CalculateFuelConsumption(Convert.ToDouble(distanceDisplay.Text)).ToString();
            }
        }

        private void VesselSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _vessel = App.Vessels.Where(vessel => vessel.Name == vesselBox.SelectedItem.ToString()).Select(vessel => vessel).First();
            CheckIfCanCalculate();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = voyages.Count == 0 ? 1 : voyages.Last().Id + 1;
                string name = nameBox.Text;
                DateTime departure = depDate.SelectedDate.Value;
                DateTime arrival = arrDate.SelectedDate.Value;

                voyages.Add(new Voyage(id, name, _vessel, _fromPort, _toPort, departure, arrival));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
