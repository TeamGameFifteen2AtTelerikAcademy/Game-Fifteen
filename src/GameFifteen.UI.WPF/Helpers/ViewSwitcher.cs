namespace GameFifteen.UI.WPF.Helpers
{
    using System;
    using System.Windows.Controls;

    public sealed class ViewSwitcher
    {
        private static readonly Lazy<ViewSwitcher> Lazy =
        new Lazy<ViewSwitcher>(
            () => new ViewSwitcher());

        private MainWindow pageSwitcher;

        private ViewSwitcher()
        {
        }

        public static ViewSwitcher Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        public MainWindow PageSwitcher
        {
            get
            {
                return this.pageSwitcher;
            }

            set
            {
                if (this.pageSwitcher == null)
                {
                    this.pageSwitcher = value;
                }
            }
        }

        public void Switch(UserControl newPage)
        {
            this.pageSwitcher.Navigate(newPage);
        }

        public void Switch(UserControl newPage, object state)
        {
            this.pageSwitcher.Navigate(newPage, state);
        }
    }
}
