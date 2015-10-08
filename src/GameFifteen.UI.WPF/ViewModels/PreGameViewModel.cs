namespace GameFifteen.UI.WPF.ViewModels
{    
    using System.Windows.Controls;

    using Helpers;

    public class PreGameViewModel : ViewModelBase
    {
        protected override void HandleSwitchViewCommand(object parameter)
        {
            var buttonClicked = parameter as Button;

            if (buttonClicked != null)
            {
                var changeToViewName = buttonClicked.Name.ToString();

                switch (changeToViewName)
                {
                    case "ButtonGoToQuickGame":
                        this.SetDefautGameSettings();
                        ViewModelsSelector.GameViewModel.HandelInitializeGameCommand(null);
                        this.PageSwitcher.Switch(ViewSelector.Game);
                        break;
                    case "ButtonGoToGameSettings":
                        this.PageSwitcher.Switch(ViewSelector.GameSettings);
                        break;
                    case "ButtonGoToAboutPage":
                        this.PageSwitcher.Switch(ViewSelector.About);
                        break;
                    default:
                        base.HandleSwitchViewCommand(parameter);
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
