// <copyright file="ViewModelBase.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ViewModelBase class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;    

    using Commands;
    using Helpers;

    /// <summary>
    /// ViewModelBase class - parent class for all other view models and holds the common commands and properties.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Holds command to switch view.
        /// </summary>
        private ICommand switchWiewCommand;

        /// <summary>
        /// Holds command to open external link.
        /// </summary>
        private ICommand openExternalLinkCommand;

        /// <summary>
        /// Holds command to quit the application.
        /// </summary>
        private ICommand quitApplicationCommand;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        public ViewModelBase()
        {
            this.PageSwitcher = ViewSwitcher.Instance;
        }

        /// <summary>
        /// Holds event for changed property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the command for switching the view.
        /// Bind with controls.
        /// </summary>
        /// <value>SwitchView as ICommand.</value>
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

        /// <summary>
        /// Gets the command for opening external link.
        /// Bind with controls.
        /// </summary>
        /// <value>OpenExternalLinkCommand as ICommand.</value>
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

        /// <summary>
        /// Gets the command for opening external link.
        /// Bind with controls.
        /// </summary>
        /// <value>OpenExternalLinkCommand as ICommand.</value>
        public ICommand QuitApplication
        {
            get
            {
                if (this.openExternalLinkCommand == null)
                {
                    this.openExternalLinkCommand = new RelayCommand(this.HandleQuitApplicationCommand);
                }

                return this.openExternalLinkCommand;
            }
        }

        /// <summary>
        /// Gets or sets view model's page switcher to work with.
        /// </summary>
        /// <value>PageSwitcher as ViewSwitcher.</value>
        protected ViewSwitcher PageSwitcher { get; set; }
          
        /// <summary>
        /// The method call PropertyChanged eventHandler by given name of property as string.
        /// </summary>
        /// <param name="propertyName">The name of property that been changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The method handles switchViewCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
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
                        this.PageSwitcher.Switch(ViewSelector.PreGame);
                        break;
                    case "ButtonGoToHallOfFame":
                        this.PageSwitcher.Switch(ViewSelector.HallOfFame);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// The method handles quitApplicationCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
        private void HandleQuitApplicationCommand(object parameter)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// The method handles openExternalLinkCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
        private void HandleOpenExternalLinkCommand(object parameter)
        {
            var buttonClicked = parameter as Button;
            var url = buttonClicked.Content.ToString();

            Process.Start(new ProcessStartInfo(url));
        }
    }
}