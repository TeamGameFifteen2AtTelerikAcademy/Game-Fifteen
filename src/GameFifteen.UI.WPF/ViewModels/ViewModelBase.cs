﻿namespace GameFifteen.UI.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Commands;
    using Helpers;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
    }
}