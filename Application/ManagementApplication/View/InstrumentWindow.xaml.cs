using ManagementApplication.Data;
using ManagementApplication.ViewModel;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
            (this.DataContext as InstrumentWindowViewModel).WindowLoaded();
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

        private void Image_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files(*.*)|*.*|png files(*.png)|*.png|jpg files(*.jpg)|*.jpg";

            if (dialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(dialog.FileName);
                _instrumentWindowViewModel.SaveImage(fileUri);
                BitmapImage bitmap = new BitmapImage(fileUri);
            }
        }

        private void Update_Image_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files(*.*)|*.*|png files(*.png)|*.png|jpg files(*.jpg)|*.jpg";

            if (dialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(dialog.FileName);
                _instrumentWindowViewModel.UpdateImage(fileUri);
                BitmapImage bitmap = new BitmapImage(fileUri);
            }
        }
    }
}
