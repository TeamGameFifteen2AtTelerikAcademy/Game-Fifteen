// <copyright file="PreGameViewModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// PreGameViewModel class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Windows.Controls;

    using Helpers;

    /// <summary>
    /// PreGameViewModel class bind with PreGameView.
    /// </summary>
    public class PreGameViewModel : ViewModelBase
    {
        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <param name="parameter">The sender object.</param>
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

        /// <summary>
        /// The method sets the default setting to the SettingsKeeper.
        /// </summary>
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
