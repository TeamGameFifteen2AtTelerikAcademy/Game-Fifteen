namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Logic.Tiles.Contracts;
    using Logic.Frames.Contracts;
    using Logic.Frames;
    using Logic.Movers.Contracts;
    using System.Collections.ObjectModel;
    using Logic.Scoreboards.Contracts;
    using Logic.Scoreboards;

    using Commands;
    using Helpers;
    using Logic.Games.Contracts;
    using Logic.Games;
    using System;

    public class GameViewModel : ViewModelBase
    {
        private IGame game;
        private IScoreboard scoreboard;
        private GameSettingsInicialisator settingsInicializator;
        private int rows;
        private int cols;
        private int moves;

        private ObservableCollection<ITile> tiles;
        private ObservableCollection<ITile> targetTiles;

        private ICommand initializeGameCommand;
        private ICommand moveTileCommand;

        public GameViewModel()
        {
            this.HandelInitializeGameCommand(null);
        }

        public ObservableCollection<ITile> Tiles
        {
            get
            {
                if (this.tiles == null)
                {
                    this.tiles = new ObservableCollection<ITile>();
                }

                return this.tiles;
            }
        }

        public ObservableCollection<ITile> TargetTiles
        {
            get
            {
                if (this.targetTiles == null)
                {
                    this.targetTiles = new ObservableCollection<ITile>();
                }

                return this.targetTiles;
            }
        }

        public ICommand InitializeGame
        {
            get
            {
                if (this.initializeGameCommand == null)
                {
                    this.initializeGameCommand = new RelayCommand(this.HandelInitializeGameCommand);
                }

                return initializeGameCommand;
            }
        }

        public ICommand MoveTile
        {
            get
            {
                if (this.moveTileCommand == null)
                {
                    this.moveTileCommand = new RelayCommand(this.HandleMoveTileCommand);
                }

                return moveTileCommand;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return cols;
            }

            set
            {
                this.cols = value;
            }
        }

        public int Moves
        {
            get
            {
                return moves;
            }

            set
            {
                this.moves = value;
            }
        }

        private void HandelInitializeGameCommand(object parameter)
        {
            this.settingsInicializator = new GameSettingsInicialisator();

            this.Rows = int.Parse(SettingsKeeper.Rows);
            this.Cols = int.Parse(SettingsKeeper.Cols);

            var tileFactory = settingsInicializator.ChooseTiles(SettingsKeeper.Tile);
            var mover = settingsInicializator.ChooseMover(SettingsKeeper.Mover);
            var frameBuilder = settingsInicializator.ChoosePattern(tileFactory, SettingsKeeper.Pattern);

            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");

            var director = new FrameDirector(frameBuilder);

            var newFrame = director.ConstructFrame(this.Rows, this.Cols);

            this.game = new Game(newFrame, mover);
            this.game.Shuffle();

            this.scoreboard = new Scoreboard();
            this.Moves = 0;

            this.tiles = new ObservableCollection<ITile>();
            this.targetTiles = new ObservableCollection<ITile>();

            this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
            this.SincFrameTilesWithObservableTiles(this.targetTiles, this.game.FramePrototype);
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("TargetTiles");
            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");
            this.OnPropertyChanged("Moves");
        }

        private void HandleMoveTileCommand(object parameter)
        {
            var button = parameter as Button;
            var label = button.Content.ToString();
            var moveSucces = this.game.Move(label);

            if (moveSucces)
            {
                this.Moves += 1;
            }

            this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);

            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("Moves");

            if (this.game.IsSolved)
            {
                MessageBox.Show(string.Format("Success - solved with {0} moves!!", this.Moves));
            }
        }

        private void HandlSshowFramePrototypeCommand(object parameter)
        {
            Window newWindow = new Window();
            newWindow.Show();
        }

        protected override void HandleSwitchViewCommand(object parameter)
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
                        this.Tiles.Clear();
                        this.TargetTiles.Clear();
                        this.OnPropertyChanged("TargetTiles");
                        this.OnPropertyChanged("Tiles");

                        break;
                    default:
                        break;
                }
            }
        }

        private void SincFrameTilesWithObservableTiles(ObservableCollection<ITile> tiles, IFrame frame)
        {
            tiles.Clear();

            for (int row = 0; row < frame.Rows; row++)
            {
                for (int col = 0; col < frame.Cols; col++)
                {
                    tiles.Add(frame.Tiles[row, col]);
                }
            }
        }
    }
}
