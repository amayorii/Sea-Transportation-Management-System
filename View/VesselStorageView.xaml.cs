using System.Windows.Controls;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for VesselStorageView.xaml
    /// </summary>
    public partial class VesselStorageView : UserControl
    {
        public VesselStorageView()
        {
            InitializeComponent();
        }
        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unloadBtn.IsEnabled = StorageList.SelectedItems != null;
        }
    }
}
