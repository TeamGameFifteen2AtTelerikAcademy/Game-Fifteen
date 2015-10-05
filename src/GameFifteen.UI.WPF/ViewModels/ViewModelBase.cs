namespace GameFifteen.UI.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Controls;

    using Helpers;
    using Commands;

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

        private void HandleSwitchViewCommand(object parameter)
        {
            var buttonClicked = parameter as Button;

            if (buttonClicked != null)
            {
                var goToViewName = buttonClicked.Name.ToString();

                switch (goToViewName)
                {
                    case "ButtonGoToQuickGame":
                        this.SetDefautGameSettings();
                        ViewSwitcher.Switch(ViewSelector.ClassicGame);
                        break;
                    case "ButtonGoToMainMenu":
                        // TODO: Switch to MainMenuView when ready
                        ViewSwitcher.Switch(ViewSelector.PreGame);
                        break;
                    case "ButtonGoToGameSettings":
                        ViewSwitcher.Switch(ViewSelector.GameSettings);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetDefautGameSettings()
        {
            SettingsKeeper.Rows = "4";
            SettingsKeeper.Cols = "4";
            SettingsKeeper.Tile = "Number";
            SettingsKeeper.Pattern = "Classic";
            SettingsKeeper.Mover = "Classic";
        }
    }
}