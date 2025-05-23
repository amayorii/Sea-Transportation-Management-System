using System.Windows;
using System.Windows.Input;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Commands
{
    public class RefuelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        readonly object refuelable;
        public RefuelCommand(object refuelable)
        {
            this.refuelable = refuelable;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                if (refuelable is Vessel vessel)
                {
                    vessel.Refuel((float)Convert.ToDecimal(parameter.ToString()));
                }
                else if (refuelable is Port port)
                {
                    port.Refuel((float)Convert.ToDecimal(parameter.ToString()));
                }
                else
                {
                    MessageBox.Show("You need to refuel refuelable object!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Input only numbers!");
            }
        }
    }
}
