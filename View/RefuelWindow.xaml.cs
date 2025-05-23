using System.Windows;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for RefuelWindow.xaml
    /// </summary>
    public partial class RefuelWindow : Window
    {
        public RefuelWindow(Vessel vessel)
        {
            InitializeComponent();
            DataContext = new RefuelViewModel(vessel);
        }
        public RefuelWindow(Port port)
        {
            InitializeComponent();
            DataContext = new RefuelViewModel(port);
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
