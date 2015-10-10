// <copyright file="ViewSwitcher.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ViewSwitcher class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Helpers
{
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// ViewSwitcher class used to hold the main window of the program and switches its inner content.
    /// </summary>
    public sealed class ViewSwitcher
    {
        /// <summary>
        /// Holds the single instance of the class.
        /// </summary>
        private static readonly Lazy<ViewSwitcher> Lazy =
        new Lazy<ViewSwitcher>(
            () => new ViewSwitcher());

        /// <summary>
        /// Holds the main window.
        /// </summary>
        private MainWindow pageSwitcher;

        /// <summary>
        /// Prevents a default instance of the ViewSwitcher class from being created.
        /// </summary>
        private ViewSwitcher()
        {
        }

        /// <summary>
        /// Gets the only instance of the class.
        /// </summary>
        /// <value>The only instance of the ViewSwitcher.</value>
        public static ViewSwitcher Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        /// <summary>
        /// Gets or sets the pageSwitcher.
        /// </summary>
        /// <value>PageSwitcher of type MainWindow.</value>
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

        /// <summary>
        /// The method switch the view of the main window with given UserControl.
        /// </summary>
        /// <param name="newPage">The new page as UserControl.</param>
        public void Switch(UserControl newPage)
        {
            this.pageSwitcher.Navigate(newPage);
        }

        /// <summary>
        /// The method switch the view of the main window with given UserControl and object state.
        /// </summary>
        /// <param name="newPage">The new page as UserControl.</param>
        /// <param name="state">The state of the object.</param>
        public void Switch(UserControl newPage, object state)
        {
            this.pageSwitcher.Navigate(newPage, state);
        }
    }
}
