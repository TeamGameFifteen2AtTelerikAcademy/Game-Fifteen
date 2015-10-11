// <copyright file="GameSettingsViewModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// GameSettingsViewModel class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Commands;
    using Helpers;

    /// <summary>
    /// GameSettingsViewModel class bind with GameSettingsView.
    /// </summary>
    public class GameSettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Holds selected rows.
        /// </summary>
        private string rows;

        /// <summary>
        /// Holds selected columns.
        /// </summary>
        private string cols;

        /// <summary>
        /// Holds selected tile type.
        /// </summary>
        private string tile;

        /// <summary>
        /// Holds selected pattern.
        /// </summary>
        private string pattern;

        /// <summary>
        /// Holds selected mover.
        /// </summary>
        private string mover;

        /// <summary>
        /// Holds OC of possible rows.
        /// </summary>
        private ObservableCollection<string> rowsPossibilities;

        /// <summary>
        /// Holds OC of possible columns.
        /// </summary>
        private ObservableCollection<string> colsPossibilities;

        /// <summary>
        /// Holds OC of possible tile types.
        /// </summary>
        private ObservableCollection<string> tileTypes;

        /// <summary>
        /// Holds OC of possible patterns.
        /// </summary>
        private ObservableCollection<string> patternTypes;

        /// <summary>
        /// Holds OC of possible mover types.
        /// </summary>
        private ObservableCollection<string> moverTypes;

        /// <summary>
        /// Holds ICommand for execute new game command.
        /// </summary>
        private ICommand newCustomGameCommand;

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>Rows as string.</value>
        public string Rows
        {
            get
            {
                if (this.rows == null)
                {
                    return "4";
                }

                return this.rows;
            }

            set
            {
                this.rows = value;
                this.OnPropertyChanged("Rows");
            }
        }

        /// <summary>
        /// Gets or sets the cols.
        /// Bind with selected value of the combo box.
        /// </summary>
        /// <value>Cols as string.</value>
        public string Cols
        {
            get
            {
                if (this.cols == null)
                {
                    return "4";
                }

                return this.cols;
            }

            set
            {
                this.cols = value;
                this.OnPropertyChanged("Cols");
            }
        }

        /// <summary>
        /// Gets or sets the tile type.
        /// Bind with selected value of the combo box.
        /// </summary>
        /// <value>Tile type as string.</value>
        public string Tile
        {
            get
            {
                if (this.tile == null)
                {
                    return "Number";
                }

                return this.tile;
            }

            set
            {
                this.tile = value;
                this.OnPropertyChanged("Tile");
            }
        }

        /// <summary>
        /// Gets or sets the patter type.
        /// Bind with selected value of the combo box.
        /// </summary>
        /// <value>Pattern type as string.</value>
        public string Pattern
        {
            get
            {
                if (this.pattern == null)
                {
                    return "Classic";
                }

                return this.pattern;
            }

            set
            {
                this.pattern = value;
                this.OnPropertyChanged("Pattern");
            }
        }

        /// <summary>
        /// Gets or sets the mover type.
        /// Bind with selected value of the combo box.
        /// </summary>
        ///  /// <summary>
        /// Gets or sets the patter type.
        /// Bind with selected value of the combo box.
        /// </summary>
        /// <value>Mover type as string.</value>
        public string Mover
        {
            get
            {
                if (this.mover == null)
                {
                    return "Classic";
                }

                return this.mover;
            }

            set
            {
                this.mover = value;
                this.OnPropertyChanged("Mover");
            }
        }

        /// <summary>
        /// Gets the possible rows.
        /// Bind with ComboBox possible values.
        /// </summary>
        /// <value>Possible rows as OC.</value>
        public ObservableCollection<string> RowsPossibilities
        {
            get
            {
                if (this.rowsPossibilities == null)
                {
                    this.rowsPossibilities = new ObservableCollection<string>() { "3", "4", "5", "6", "7", "8", "9", "10" };
                }

                return this.rowsPossibilities;
            }
        }

        /// <summary>
        /// Gets the possible cols.
        /// Bind with ComboBox possible values.
        /// </summary>
        /// <value>Possible cols as OC.</value>
        public ObservableCollection<string> ColsPossibilities
        {
            get
            {
                if (this.colsPossibilities == null)
                {
                    this.colsPossibilities = new ObservableCollection<string>() { "3", "4", "5", "6", "7", "8", "9", "10" };
                }

                return this.colsPossibilities;
            }
        }

        /// <summary>
        /// Gets the possible tile types.
        /// Bind with ComboBox possible values.
        /// </summary>
        /// <value>Possible tile types as OC.</value>
        public ObservableCollection<string> TileTypes
        {
            get
            {
                if (this.tileTypes == null)
                {
                    this.tileTypes = new ObservableCollection<string>() { "Number", "Letter" };
                }

                return this.tileTypes;
            }
        }

        /// <summary>
        /// Gets the possible pattern types.
        /// Bind with ComboBox possible values.
        /// </summary>
        /// /// <value>Possible pattern types as OC.</value>
        public ObservableCollection<string> PatternTypes
        {
            get
            {
                if (this.patternTypes == null)
                {
                    this.patternTypes = new ObservableCollection<string>() { "Classic", "Column" };
                }

                return this.patternTypes;
            }
        }

        /// <summary>
        /// Gets the possible mover type.
        /// Bind with ComboBox possible values.
        /// </summary>
        /// /// <value>Possible mover types as OC.</value>
        public ObservableCollection<string> MoverTypes
        {
            get
            {
                if (this.moverTypes == null)
                {
                    this.moverTypes = new ObservableCollection<string>() { "Classic", "RowCol" };
                }

                return this.moverTypes;
            }
        }

        /// <summary>
        /// Gets the ICommand for new game.
        /// Bind with button.
        /// </summary>
        /// <value>NewCustomGame as ICommand.</value>
        public ICommand NewCustomGame
        {
            get
            {
                if (this.newCustomGameCommand == null)
                {
                    this.newCustomGameCommand = new RelayCommand(this.HandlenewCustomGameCommand);
                }

                return this.newCustomGameCommand;
            }
        }

        /// <summary>
        /// The method handles the execution of new custom game.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
        private void HandlenewCustomGameCommand(object parameter)
        {
            SettingsKeeper.Rows = this.Rows;
            SettingsKeeper.Cols = this.Cols;
            SettingsKeeper.Tile = this.Tile;
            SettingsKeeper.Pattern = this.Pattern;
            SettingsKeeper.Mover = this.Mover;

            ViewModelsSelector.GameViewModel.HandelInitializeGameCommand(null);

            this.PageSwitcher.Switch(ViewSelector.Game);
        }
    }
}
