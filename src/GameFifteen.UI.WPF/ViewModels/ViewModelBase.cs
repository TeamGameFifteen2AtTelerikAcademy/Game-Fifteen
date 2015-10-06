namespace GameFifteen.UI.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Controls;

    using Helpers;
    using Commands;
    using System.Windows.Documents;
    using System.Diagnostics;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand quickGameCOmmand;

        public ICommand SwitchView
        {
            get
            {
                if (this.quickGameCOmmand == null)
                {
                    this.quickGameCOmmand = new RelayCommand(this.HandleSwitchViewCommand);
                }

                return quickGameCOmmand;
            }
        }

        protected virtual void HandleSwitchViewCommand(object parameter)
        {
            var buttonClicked = parameter as Button;

            if (buttonClicked != null)
            {
                var goToViewName = buttonClicked.Name.ToString();

                switch (goToViewName)
                {
                    case "ButtonGoToMainMenu":
                        // TODO: Switch to MainMenuView when ready
                        ViewSwitcher.Switch(ViewSelector.PreGame);
                        break;
                    default:
                        break;
                }
            }
        }

        private ICommand openExternalLinkCommand;

        public ICommand OpenExternalLinkCommand
        {
            get
            {
                if (this.openExternalLinkCommand == null)
                {
                    this.openExternalLinkCommand = new RelayCommand(this.HandleOpenExternalLinkCommand);
                }

                return openExternalLinkCommand;
            }
        }

        private void HandleOpenExternalLinkCommand(object parameter)
        {
            var buttonClicked = parameter as Button;
            var url = buttonClicked.Content.ToString();

            Process.Start(new ProcessStartInfo(url));
        }
    }
}