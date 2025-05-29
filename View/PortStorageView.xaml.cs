using System.Windows.Controls;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for PortStorageView.xaml
    /// </summary>
    public partial class PortStorageView : UserControl
    {
        public PortStorageView()
        {
            InitializeComponent();
        }
        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadBtn.IsEnabled = StorageList.SelectedItems != null;
        }
    }
}
