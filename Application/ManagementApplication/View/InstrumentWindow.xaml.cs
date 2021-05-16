using ManagementApplication.Data;
using ManagementApplication.ViewModel;
using System.Windows;

namespace ManagementApplication.View
{
    /// <summary>
    /// Interaction logic for InstrumentWindow.xaml
    /// </summary>
    public partial class InstrumentWindow : Window
    {
        private InstrumentWindowViewModel _instrumentWindowViewModel;

        public InstrumentWindow(InstrumentWindowViewModel instrumentWindowViewModel)
        {
            _instrumentWindowViewModel = instrumentWindowViewModel;
            this.DataContext = instrumentWindowViewModel;
            InitializeComponent();
            (this.DataContext as InstrumentWindowViewModel).Window_Loaded();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedProductToDelete = (sender as FrameworkElement).DataContext as Instrument;
            _instrumentWindowViewModel.DeleteSelectedInstrument(selectedProductToDelete);
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedProductToEdit = (sender as FrameworkElement).DataContext as Instrument;
            _instrumentWindowViewModel.ChangeSelectedInstrument(selectedProductToEdit);
        }
    }
}
