using ManagementApplication.Model;
using ManagementApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        private ApplicationModel _appModel;
        private MainWindowViewModel _appViewModel;

        #endregion

        #region Constructor

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        #endregion

        #region Application event handlers

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _appModel = new ApplicationModel();
            _appViewModel = new MainWindowViewModel(_appModel);
            _view = new MainWindow();
            _view.DataContext = _appViewModel;
            _view.Show();
        }

        #endregion
    }
}
