using ManagementApplication.View;

namespace ManagementApplication.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private InstrumentWindow _instrumentWindow;
        private InstrumentWindowViewModel _instrumentWindowViewModel;
        private OrderWindow _orderWindow;
        private OrderWindowViewModel _orderWindowViewModel;

        #endregion

        #region Properties

        public DelegateCommand InstrumentClickCommand { get; private set; }
        public DelegateCommand OrderClickCommand { get; private set; }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            InstrumentClickCommand = new DelegateCommand(param => OpenInstrumentWindow());
            OrderClickCommand = new DelegateCommand(param => OpenOrderWindow());
        }

        #endregion


        #region Private methods

        private void OpenInstrumentWindow()
        {
            _instrumentWindowViewModel = new InstrumentWindowViewModel();
            _instrumentWindow = new InstrumentWindow(_instrumentWindowViewModel);
            _instrumentWindow.Show();
        }

        private void OpenOrderWindow()
        {
            _orderWindowViewModel = new OrderWindowViewModel();
            _orderWindow = new OrderWindow(_orderWindowViewModel);
            _orderWindow.Show();
        }

        #endregion
    }
}
