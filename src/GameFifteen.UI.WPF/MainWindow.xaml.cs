namespace GameFifteen.UI.WPF
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using Contracts;
    using Helpers;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.PageSwitcher = ViewSwitcher.Instance;
            this.PageSwitcher.PageSwitcher = this;
            this.PageSwitcher.Switch(ViewSelector.PreGame);
        }

        private ViewSwitcher PageSwitcher { get; set; }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable stateStatus = nextPage as ISwitchable;

            if (stateStatus != null)
            {
                stateStatus.UtilizeState(state);
            }
            else
            {
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
            }
        }
    }
}
