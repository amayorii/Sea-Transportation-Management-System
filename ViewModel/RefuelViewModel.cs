using System.Windows.Input;
using Sea_Transportation_Management_System.Commands;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.ViewModel
{
    public class RefuelViewModel : ViewModelBase
    {
        public string CurrentFuel { get; }
        public ICommand RefuelCommand { get; }
        public RefuelViewModel(IRefuelable refuelable)
        {
            if (refuelable is Vessel vessel)
            {
                RefuelCommand = new RefuelCommand(vessel);
                CurrentFuel = vessel.Fuel.ToString();
            }
            else if (refuelable is Port port)
            {
                RefuelCommand = new RefuelCommand(port);
                CurrentFuel = port.FuelStock.ToString();
            }
        }
    }
}
