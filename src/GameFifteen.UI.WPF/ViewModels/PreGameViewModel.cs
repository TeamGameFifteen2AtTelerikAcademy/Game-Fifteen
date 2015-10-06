namespace GameFifteen.UI.WPF.ViewModels
{
    using Helpers;
    using System.Windows.Controls;

    public class PreGameViewModel : ViewModelBase
    {
        protected override void HandleSwitchViewCommand(object parameter)
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
                    case "ButtonGoToGameSettings":
                        ViewSwitcher.Switch(ViewSelector.GameSettings);
                        break;
                    case "ButtonGoToAboutPage":
                        ViewSwitcher.Switch(ViewSelector.About);
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
