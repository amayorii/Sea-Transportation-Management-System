using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for ViewStorageWindow.xaml
    /// </summary>
    public partial class ViewStorageWindow : Window
    {
        public ViewStorageWindow(IStoragable storagable)
        {
            InitializeComponent();
            DataContext = new StorageViewModel(storagable);
        }
    }
}
