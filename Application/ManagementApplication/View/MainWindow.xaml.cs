using ManagementApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ManagementApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InstrumentContext _context = new InstrumentContext();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
