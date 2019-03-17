using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace jamoin.demo.testability.startup.Utils
{
    public class DelegateCommand : ICommand
    {
        //These delegates store methods to be called that contains the body of the Execute and CanExecue methods
        //for each particular instance of DelegateCommand.
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        //Two Constructors, for convenience and clean code - often you won't need CanExecute
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        //CanExecute and Execute come from ICommand
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _execute(parameter);
        }
    }
}
