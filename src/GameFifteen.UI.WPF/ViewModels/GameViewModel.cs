namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Commands;
    using Helpers;
    using Logic.Frames;
    using Logic.Frames.Contracts;
    using Logic.Games;
    using Logic.Games.Contracts;
    using Logic.Memento;
    using Logic.Scoreboards;
    using Logic.Scoreboards.Contracts;
    using Logic.Tiles.Contracts;

    public class GameViewModel : ViewModelBase
    {
        private readonly GameSettingsInitializer settingsInicializator;

        private IGame game;
        private int rows;
        private int cols;
        private int moves;
        private bool isResumeBurronVissible = false;
        private string topPlayerName;

        private ObservableCollection<ITile> tiles;
        private ObservableCollection<ITile> targetTiles;
        private ObservableCollection<IScore> topScores;

        private ICommand undoMoveCommand;
        private ICommand initializeGameCommand;
        private ICommand moveTileCommand;
        private ICommand topPlayerResultCommitCommand;

        public GameViewModel()
        {
            this.settingsInicializator = new GameSettingsInitializer();
            this.BoardHistory = new BoardHistory();
            this.ScoreboardInfo = new Scoreboard();
            SettingsKeeper.ScoreBoard = this.ScoreboardInfo;
        }

        public IMemento BoardHistory { get; set; }

        public IScoreboard ScoreboardInfo { get; set; }

        public bool IsResumeBurronVissible
        {
            get
            {
                return this.isResumeBurronVissible;
            }

            set
            {
                this.isResumeBurronVissible = value;
                this.OnPropertyChanged("IsResumeBurronVissible");
            }
        }

        public string TopPlayerName
        {
            get
            {
                return this.topPlayerName;
            }

            set
            {
                this.topPlayerName = value;
                this.OnPropertyChanged("TopPlayerName");
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                this.rows = value;
                this.OnPropertyChanged("Rows");
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            set
            {
                this.cols = value;
                this.OnPropertyChanged("Cols");
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }

            set
            {
                this.moves = value;
                this.OnPropertyChanged("Moves");
            }
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

        public ObservableCollection<IScore> TopScores
        {
            get
            {
                if (this.topScores == null)
                {
                    this.topScores = new ObservableCollection<IScore>();
                }

                return this.topScores;
            }
        }

        public ICommand UndoMove
        {
            get
            {
                if (this.undoMoveCommand == null)
                {
                    this.undoMoveCommand = new RelayCommand(this.HandelUndoMoveCommand);
                }

                return this.undoMoveCommand;
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

                return this.initializeGameCommand;
            }
        }

        public ICommand TopPlayerResultCommit
        {
            get
            {
                if (this.topPlayerResultCommitCommand == null)
                {
                    this.topPlayerResultCommitCommand = new RelayCommand(this.HandelTopPlayerResultCommitCommand);
                }

                return this.topPlayerResultCommitCommand;
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

                return this.moveTileCommand;
            }
        }

        public void HandelInitializeGameCommand(object parameter)
        {
            this.TopPlayerName = "Some Player";
            this.Rows = int.Parse(SettingsKeeper.Rows);
            this.Cols = int.Parse(SettingsKeeper.Cols);

            var tileFactory = this.settingsInicializator.ChooseTiles(SettingsKeeper.Tile);
            var mover = this.settingsInicializator.ChooseMover(SettingsKeeper.Mover);
            var frameBuilder = this.settingsInicializator.ChoosePattern(tileFactory, SettingsKeeper.Pattern);

            var director = new FrameDirector(frameBuilder);

            var newFrame = director.ConstructFrame(this.Rows, this.Cols);

            this.game = new Game(newFrame, mover);
            this.game.Shuffle();

            this.Moves = 0;

            this.topScores = new ObservableCollection<IScore>();
            this.tiles = new ObservableCollection<ITile>();
            this.targetTiles = new ObservableCollection<ITile>();
            this.BoardHistory.SaveBoardState(this.game.Frame);

            this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
            this.SincFrameTilesWithObservableTiles(this.targetTiles, this.game.FramePrototype);

            this.IsResumeBurronVissible = true;

            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("TargetTiles");
        }

        protected override void HandleSwitchViewCommand(object parameter)
        {
            var buttonClicked = parameter as Button;

            if (buttonClicked != null)
            {
                string changeToViewName = buttonClicked.Name.ToString();

                switch (changeToViewName)
                {
                    case "ButtonResumeCurrentGame":
                        this.PageSwitcher.Switch(ViewSelector.Game);
                        break;
                    default:
                        base.HandleSwitchViewCommand(parameter);
                        break;
                }
            }
        }

        private void HandelUndoMoveCommand(object parameter)
        {
            if (this.Moves > 0)
            {
                this.game.Frame = this.BoardHistory.Undo();

                this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
                this.Moves -= 1;

                this.OnPropertyChanged("Tiles");
                this.OnPropertyChanged("Moves");
            }
        }

        private void HandleMoveTileCommand(object parameter)
        {
            this.BoardHistory.SaveBoardState(this.game.Frame);

            var button = parameter as Button;
            var label = button.Content.ToString();
            var moveSucces = this.game.Move(label);

            if (moveSucces)
            {
                this.Moves += 1;
                this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
                this.OnPropertyChanged("Tiles");
            }

            if (this.game.IsSolved)
            {
                this.SetGameEnd();
            }
        }

        private void HandelTopPlayerResultCommitCommand(object parameter)
        {
            this.ScoreboardInfo.Add(this.Moves, this.TopPlayerName);
            this.SincTopScoresWIthsObservableScores(this.topScores, this.ScoreboardInfo.GetTopScores());
            this.OnPropertyChanged("TopScores");
            this.PageSwitcher.Switch(ViewSelector.HallOfFame);
        }

        private void SetGameEnd()
        {
            this.IsResumeBurronVissible = false;
            bool isTopResult = this.ScoreboardInfo.IsInTopScores(this.Moves);

            if (isTopResult)
            {
                this.PageSwitcher.Switch(ViewSelector.CompleteTopScoreGame);
            }
            else
            {
                this.PageSwitcher.Switch(ViewSelector.JustCompletedGame);
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

        private void SincTopScoresWIthsObservableScores(ObservableCollection<IScore> observableScore, IList<IScore> scores)
        {
            observableScore.Clear();

            foreach (var score in scores)
            {
                observableScore.Add(score);
            }
        }
    }
}
