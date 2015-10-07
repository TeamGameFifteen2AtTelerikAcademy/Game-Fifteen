namespace GameFifteen.UI.WPF.Helpers
{
    using System.Windows.Controls;
    
    public static class ViewSwitcher
    {
        private static MainWindow pageSwitcher;

        public static MainWindow PageSwitcher
        {
            get
            {
                return pageSwitcher;
            }

            set
            {
                pageSwitcher = value;
            }
        }

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
