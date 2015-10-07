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
    using Logic.Memento;
    using Logic;
    using System.Collections.Generic;

    public class GameViewModel : ViewModelBase
    {
        private IGame game;        
        private GameSettingsInicialisator settingsInicializator;
        private int rows;
        private int cols;
        private int moves;

        private string topPlayerName;

        private ObservableCollection<ITile> tiles;
        private ObservableCollection<ITile> targetTiles;
        private ObservableCollection<IScore> topScores;

        private ICommand undoMoveCommand;
        private ICommand initializeGameCommand;
        private ICommand moveTileCommand;
        private ICommand topPlayerResultCommitCommand;

        private ICommand getTopScores;

        public IMemento BoardHistory { get; set; }
        public IScoreboard ScoreboardInfo { get; set; }

        public bool isResumeBurronVissible = false;

        public bool IsResumeBurronVissible
        {
            get
            {                
                return isResumeBurronVissible;
            }

            set
            {
                isResumeBurronVissible = value;
                OnPropertyChanged("IsResumeBurronVissible");
            }
        }

        public GameViewModel()
        {
            this.settingsInicializator = new GameSettingsInicialisator();
            this.BoardHistory = new BoardHistory();
            this.ScoreboardInfo = new Scoreboard();
            SettingsKeeper.ScoreBoard = this.ScoreboardInfo;
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

                return undoMoveCommand;
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

        public ICommand TopPlayerResultCommit
        {
            get
            {
                if (this.topPlayerResultCommitCommand == null)
                {
                    this.topPlayerResultCommitCommand = new RelayCommand(this.HandelTopPlayerResultCommitCommand);
                }

                return topPlayerResultCommitCommand;
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

        public ICommand GetTopScores
        {
            get
            {
                if (this.getTopScores == null)
                {
                    this.getTopScores = new RelayCommand(this.HandlGameCompletedCommand);
                }

                return getTopScores;
            }
        }

        public string TopPlayerName
        {
            get
            {
                return topPlayerName;
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
                return rows;
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
                return cols;
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
                return moves;
            }

            set
            {
                this.moves = value;
                this.OnPropertyChanged("Moves");
            }
        }

        public void HandelInitializeGameCommand(object parameter)
        {
            this.TopPlayerName = "Some Player";
            this.Rows = int.Parse(SettingsKeeper.Rows);
            this.Cols = int.Parse(SettingsKeeper.Cols);

            var tileFactory = settingsInicializator.ChooseTiles(SettingsKeeper.Tile);
            var mover = settingsInicializator.ChooseMover(SettingsKeeper.Mover);
            var frameBuilder = settingsInicializator.ChoosePattern(tileFactory, SettingsKeeper.Pattern);            

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

            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("TargetTiles");
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

        private void HandlGameCompletedCommand(object parameter)
        {           
            this.OnPropertyChanged("TopScores");
            this.OnPropertyChanged("TopScores");
            this.OnPropertyChanged("TopScores");
        }

        private void SetGameEnd()
        {
            this.IsResumeBurronVissible = false;
            var IsTopResult = this.ScoreboardInfo.IsInTopScores(this.Moves);

            if (IsTopResult)
            {
                ViewSwitcher.Switch(ViewSelector.CompleteTopScoreGame);
            }

            else
            {
                ViewSwitcher.Switch(ViewSelector.JustCompletedGame);
            }
        }

        private void HandelTopPlayerResultCommitCommand(object parameter)
        {
            this.ScoreboardInfo.Add(this.Moves, this.TopPlayerName);
            this.SincTopScoresWIthsObservableScores(this.topScores, this.ScoreboardInfo.GetTopScores());
            this.OnPropertyChanged("TopScores");
            ViewSwitcher.Switch(ViewSelector.HallOfFame);
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
