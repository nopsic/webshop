using ManagementApplication.Data;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.ViewModel
{
    public class OrderWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly InstrumentRepository _instrumentRepository = new InstrumentRepository();
        private Order _selectedOrder;
        private ObservableCollection<Order> _collection;

        #endregion

        #region Properties

        public DelegateCommand RefreshCommand { get; private set; }

        public ObservableCollection<Order> OrderData
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
                OnPropertyChanged("OrderData");
            }
        }

        public Order SelectedOrder 
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        #endregion

        #region Constructor

        public OrderWindowViewModel()
        {
            RefreshCommand = new DelegateCommand(param => WindowLoaded());

            SelectedOrder = new Order();
        }

        #endregion

        #region Public methods

        public async void WindowLoaded()
        {
            var orders = await _instrumentRepository.GetOrdersAsync();

            var list = orders.ToList();

            OrderData = new ObservableCollection<Order>(list);
        }

        public void ChangeSelectedOrder(Order order)
        {
            SelectedOrder = new Order(order);
        }

        public async void ChangeStatus(string status)
        {
            var order = await _instrumentRepository.GetOrdersByOrderNumberToSetStatusAsync(SelectedOrder.OrderNumber, status);

            if (order == null)
            {
                MessageBox.Show("There no order with this number", "Error");
                return;
            }
            else 
            {
                await _instrumentRepository.SaveChangesAsync();
                await this.SendEmailAfterStatusChanged(SelectedOrder.OrderNumber);
                WindowLoaded();
                SelectedOrder = new Order();
            }
        }

        public async Task<bool> SendEmailAfterStatusChanged(int orderNumber)
        {
            var orders = await _instrumentRepository.GetOrdersByOrderNumberAsync(orderNumber);

            if (orders == null)
            {
                return false;
            }

            var fromAddress = "szakdolgozatiemail@gmail.com";
            var toAddress = orders[0].Email;
            const string fromPassword = "Qwerty49";
            string subject = $"Order status changed - #{orders[0].OrderNumber}";

            string body = $"Your order status changed, {orders[0].FirstName} {orders[0].LastName}!\n\nOrder status: {orders[0].Status}\n\nHere is your list of order: \n\n";

            int total = 0;

            foreach (var item in orders)
            {
                body += $"Instrument: {item.InstrumentName}, Instrument Code: {item.Code}, Quantity: {item.Quantity}, Price: {item.Price.ToString("N0", new CultureInfo("hu-HU"))} Ft\n";
                total += item.Price;
            }
            body += $"\nTotal: {total.ToString("N0", new CultureInfo("hu-HU"))} Ft\n\nOrder was placed at: {orders[0].Date}\n\nBest regards,\nWebshop team";

            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = fromAddress,
                    Password = fromPassword
                }
            };
            MailAddress FromEmail = new MailAddress(fromAddress, "Webshop");
            MailAddress ToEmail = new MailAddress(toAddress, orders[0].FirstName + " " + orders[0].LastName);

            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = subject,
                Body = body
            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
                MessageBox.Show("Sent Successfully", "Done");

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong \n" + e.InnerException.Message, "Error");

                return false;
            }
        }

        public async void SendEmail(Order order)
        {
            var orders = await _instrumentRepository.GetOrdersByOrderNumberAsync(order.OrderNumber);

            if (orders == null)
            {
                return;
            }

            var fromAddress = "szakdolgozatiemail@gmail.com";
            var toAddress = orders[0].Email;
            const string fromPassword = "Qwerty49";
            string subject = $"Bill - #{orders[0].OrderNumber}";

            string body = $"Thank you for your purchase, {orders[0].FirstName} {orders[0].LastName}!\n\n" +
                $"Billing City: {orders[0].BillingCity}\nBilling State: {orders[0].BillingState}\nBilling Postal Code: {orders[0].BillingPostalCode}\n" +
                $"Billing Address: {orders[0].BillingAddress}\n\nHere is your list of order: \n\n";

            int total = 0;

            foreach (var item in orders)
            {
                body += $"Instrument: {item.InstrumentName}, Instrument Code: {item.Code}, Quantity: {item.Quantity}, Price: {item.Price.ToString("N0", new CultureInfo("hu-HU"))} Ft\n";
                total += item.Price;
            }
            body += $"\nTotal: {total.ToString("N0", new CultureInfo("hu-HU"))} Ft\n\nBest regards,\nWebshop team";

            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = fromAddress,
                    Password = fromPassword
                }
            };
            MailAddress FromEmail = new MailAddress(fromAddress, "Webshop");
            MailAddress ToEmail = new MailAddress(toAddress, orders[0].FirstName + " " + orders[0].LastName);

            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = subject,
                Body = body
            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
                MessageBox.Show("Sent Successfully", "Done");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong \n" + e.InnerException.Message, "Error");
            }
        }

        #endregion
    }
}
