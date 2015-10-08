namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Commands;
    using Helpers;

    public class GameSettingsViewModel : ViewModelBase
    {
        private string rows;
        private string cols;
        private string tile;
        private string pattern;
        private string mover;

        private ObservableCollection<string> rowsPossibilities;
        private ObservableCollection<string> colsPossibilities;
        private ObservableCollection<string> tileTypes;
        private ObservableCollection<string> patternTypes;
        private ObservableCollection<string> moverTypes;

        private ICommand newCustomGameCommand;

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
            }
        }

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
            }
        }

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
            }
        }

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
            }
        }

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
            }
        }

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

        private void HandlenewCustomGameCommand(object parameter)
        {
            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");
            this.OnPropertyChanged("TileType");
            this.OnPropertyChanged("PatternType");
            this.OnPropertyChanged("MoverType");

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
