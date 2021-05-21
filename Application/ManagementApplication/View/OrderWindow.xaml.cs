using ManagementApplication.Data;
using ManagementApplication.ViewModel;
using System.Windows;

namespace ManagementApplication.View
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private OrderWindowViewModel _orderWindowViewModel;

        public OrderWindow(OrderWindowViewModel orderWindowViewModel)
        {
            _orderWindowViewModel = orderWindowViewModel;
            this.DataContext = _orderWindowViewModel;
            InitializeComponent();
            (this.DataContext as OrderWindowViewModel).WindowLoaded();
        }

        private void Edite_Selected_Order(object sender, RoutedEventArgs e)
        {
            var selectedOrder = (sender as FrameworkElement).DataContext as Order;
            _orderWindowViewModel.ChangeSelectedOrder(selectedOrder);
        }

        private void changeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (statusComboBox.SelectedItem != null)
            {
                var status = (statusComboBox.Text).ToString();
                _orderWindowViewModel.ChangeStatus(status);
            }
        }

        private void Create_Bill_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = (sender as FrameworkElement).DataContext as Order;
            _orderWindowViewModel.SendEmail(selectedOrder);
        }
    }
}
