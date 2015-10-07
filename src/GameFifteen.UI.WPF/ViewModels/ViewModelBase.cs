namespace GameFifteen.UI.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;

    using Commands;
    using Helpers;

    public class ViewModelBase : INotifyPropertyChanged
    {
        private ICommand switchWiewCommand;
        private ICommand openExternalLinkCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SwitchView
        {
            get
            {
                if (this.switchWiewCommand == null)
                {
                    this.switchWiewCommand = new RelayCommand(this.HandleSwitchViewCommand);
                }

                return this.switchWiewCommand;
            }
        }

        public ICommand OpenExternalLinkCommand
        {
            get
            {
                if (this.openExternalLinkCommand == null)
                {
                    this.openExternalLinkCommand = new RelayCommand(this.HandleOpenExternalLinkCommand);
                }

                return this.openExternalLinkCommand;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void HandleSwitchViewCommand(object parameter)
        {
            var buttonClicked = parameter as Button;

            if (buttonClicked != null)
            {
                string changeToViewName = buttonClicked.Name.ToString();

                switch (changeToViewName)
                {
                    case "ButtonGoToMainMenu":
                        // TODO: Switch to MainMenuView when ready
                        ViewSwitcher.Switch(ViewSelector.PreGame);
                        break;
                    case "ButtonGoToHallOfFame":
                        ViewSwitcher.Switch(ViewSelector.HallOfFame);
                        break;
                    default:
                        break;
                }
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