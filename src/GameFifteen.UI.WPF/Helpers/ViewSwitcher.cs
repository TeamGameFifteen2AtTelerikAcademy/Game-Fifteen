namespace GameFifteen.UI.WPF.Helpers
{
    using System.Windows.Controls;

    // TODO: To implement Singleton Pattern for ViewSwitcher
    public static class ViewSwitcher
    {
        public static MainWindow PageSwitcher;

        public static void Switch(UserControl newPage)
        {
            PageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            PageSwitcher.Navigate(newPage, state);
        }
    }
}
