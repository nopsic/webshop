using System;
using System.Windows.Input;

namespace ManagementApplication.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<Object> _execute;
        private readonly Func<Object, Boolean> _canExecute;

        public DelegateCommand(Action<Object> execute, Func<Object, Boolean> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);

        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
