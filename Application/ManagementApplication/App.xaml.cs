using ManagementApplication.ViewModel;
using System.Windows;

namespace ManagementApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private MainWindow _view;
        private MainWindowViewModel _appViewModel;

        #endregion

        #region Constructor

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        #endregion

        #region Event handlers

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _appViewModel = new MainWindowViewModel();
            _view = new MainWindow();
            _view.DataContext = _appViewModel;
            _view.Show();
        }



        #endregion
    }
}
