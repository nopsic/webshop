using ManagementApplication.Model;

namespace ManagementApplication.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private ApplicationModel _appModel;

        #endregion

        #region Constructor

        public MainWindowViewModel(ApplicationModel appModel)
        {
            _appModel = appModel;
        }

        #endregion
    }
}
