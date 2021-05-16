using ManagementApplication.View;

namespace ManagementApplication.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private InstrumentWindow _newInstrumentWindow;
        private InstrumentWindowViewModel _newInstrumentWindowViewModel;

        #endregion

        #region Properties

        public DelegateCommand InstrumentClickCommand { get; private set; }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            InstrumentClickCommand = new DelegateCommand(param => OpenInstrumentWindow());
        }

        #endregion


        #region Private methods

        private void OpenInstrumentWindow()
        {
            _newInstrumentWindowViewModel = new InstrumentWindowViewModel();
            _newInstrumentWindow = new InstrumentWindow(_newInstrumentWindowViewModel);
            _newInstrumentWindow.Show();
        }

        #endregion
    }
}
