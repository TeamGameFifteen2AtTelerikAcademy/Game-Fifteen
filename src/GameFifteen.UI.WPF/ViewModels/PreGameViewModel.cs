namespace GameFifteen.UI.WPF.ViewModels
{
    using Commands;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class PreGameViewModel : ViewModelBase
    {
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
                    case "ButtonGoToQuickGame": ViewSwitcher.Switch(ViewSelector.PreGame);
                        MessageBox.Show(goToViewName);
                        break;
                    default:
                        break;
                }

            }
           

        }
    }
}
