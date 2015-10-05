namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Windows.Input;
    using System.Collections.ObjectModel;

    using Commands;
    using Helpers;
    using System.Windows.Controls;

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

        public string Rows
        {
            get
            {
                if( this.rows == null)
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

                return mover;
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
                    this.rowsPossibilities = new ObservableCollection<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
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
                    this.colsPossibilities = new ObservableCollection<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
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
                    this.tileTypes = new ObservableCollection<string>() {"Number", "Letter" };
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

        private ICommand newCustomGameCommand;

        public ICommand NewCustomGame
        {
            get
            {
                if (this.newCustomGameCommand == null)
                {
                    this.newCustomGameCommand = new RelayCommand(this.HandlenewCustomGameCommand);
                }

                return newCustomGameCommand;
            }
        }

        private void HandlenewCustomGameCommand(object parameter)
        {
            OnPropertyChanged("Rows");
            OnPropertyChanged("Cols");
            OnPropertyChanged("TileType");
            OnPropertyChanged("PatternType");
            OnPropertyChanged("MoverType");


            SettingsKeeper.Rows = this.Rows;
            SettingsKeeper.Cols = this.Cols;
            SettingsKeeper.Tile = this.Tile;
            SettingsKeeper.Pattern = this.Pattern;
            SettingsKeeper.Mover = this.Mover;

            //  var vm = new ClassicGameViewModel(int.Parse(this.Rows), int.Parse(this.Cols), this.Tile, this.Pattern, this.Mover);

            ViewSwitcher.Switch(ViewSelector.ClassicGame);           
            
        }       
    }
}
