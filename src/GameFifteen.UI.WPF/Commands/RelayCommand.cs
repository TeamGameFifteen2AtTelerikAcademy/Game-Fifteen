namespace GameFifteen.UI.WPF.Commands
{
    using System;
    using System.Windows.Input;

    public delegate void ExecuteDelegate(object parameter);
    public delegate bool CanExecuteDelegate(object parameter);

    public class RelayCommand : ICommand
    {
        private ExecuteDelegate execute;
        private CanExecuteDelegate canExecute;
        private Logic.Commands.ICommand openExternalLinkCommand;

        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {
        }

        public RelayCommand(ExecuteDelegate execute,
            CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Logic.Commands.ICommand openExternalLinkCommand)
        {
            this.openExternalLinkCommand = openExternalLinkCommand;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
