// <copyright file="GameViewModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// GameViewModel class.
// </summary>
// <author>GameFifteen2Team</author>

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

    /// <summary>
    /// GameViewModel class bind with GameView.
    /// </summary>
    public class GameViewModel : ViewModelBase
    {
        /// <summary>
        /// Holds GameSettingsInitializer.
        /// </summary>
        private readonly GameSettingsInitializer settingsInicializator;

        /// <summary>
        /// Holds IGame.
        /// </summary>
        private IGame game;

        /// <summary>
        /// Holds Frame Rows.
        /// </summary>
        private int rows;

        /// <summary>
        /// Holds Frame cols.
        /// </summary>
        private int cols;

        /// <summary>
        /// Holds current moves.
        /// </summary>
        private int moves;

        /// <summary>
        /// Holds if the game is in progress.
        /// </summary>
        private bool isResumeBurronVissible = false;

        /// <summary>
        /// Holds the name of the player which has top result.
        /// </summary>
        private string topPlayerName;

        /// <summary>
        /// Holds OC of ITile that represents the game's frame.
        /// </summary>
        private ObservableCollection<ITile> tiles;

        /// <summary>
        /// Holds OC of ITile that represents the game's prototype frame.
        /// </summary>
        private ObservableCollection<ITile> targetTiles;

        /// <summary>
        /// Holds OC of IScore that represents the IScoreboard's tops scores.
        /// </summary>
        private ObservableCollection<IScore> topScores;

        /// <summary>
        /// Holds command for undo move.
        /// </summary>
        private ICommand undoMoveCommand;

        /// <summary>
        /// Holds command for initializing game.
        /// </summary>
        private ICommand initializeGameCommand;

        /// <summary>
        /// Holds command for moving a tile.
        /// </summary>
        private ICommand moveTileCommand;

        /// <summary>
        /// Holds command for commit a top result to the IScoreboard.
        /// </summary>
        private ICommand topPlayerResultCommitCommand;

        /// <summary>
        /// Initializes a new instance of the GameViewModel class.
        /// </summary>
        public GameViewModel()
        {
            this.settingsInicializator = new GameSettingsInitializer();
            this.BoardHistory = new BoardHistory();
            this.ScoreboardInfo = new Scoreboard();
            SettingsKeeper.ScoreBoard = this.ScoreboardInfo;
        }

        /// <summary>
        /// Gets or sets BoardHistory.
        /// </summary>
        /// <value>BoardHistory as IMemento.</value>
        public IMemento BoardHistory { get; set; }

        /// <summary>
        /// Gets or sets ScoreboardInfo.
        /// </summary>
        /// <value>BoardHistory as IScoreboard.</value>
        public IScoreboard ScoreboardInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the resume button to be visible.
        /// Bind with controls.
        /// </summary>
        /// <value>The state of the button as boolean.</value>
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

        /// <summary>
        /// Gets or sets the top player's name.
        /// Bind with controls.
        /// </summary>
        /// <value>The top player's name as string.</value>
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

        /// <summary>
        /// Gets or sets the row of the game's frame.
        /// Bind with controls.
        /// </summary>
        /// <value>The rows as integer.</value>
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

        /// <summary>
        /// Gets or sets the cols of the game's frame.
        /// Bind with controls.
        /// </summary>
        /// <value>The cols as integer.</value>
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

        /// <summary>
        /// Gets or sets the current moves.
        /// Bind with controls.
        /// </summary>
        /// <value>The moves as integer.</value>
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

        /// <summary>
        /// Gets the game's frame as OC.
        /// Bind with controls.
        /// </summary>
        /// <value>OC of ITiles.</value>
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

        /// <summary>
        /// Gets the game's prototype frame as OC.
        /// Bind with controls.
        /// </summary>
        /// <value>OC of ITiles.</value>
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

        /// <summary>
        /// Gets the scoreboard's top scores as OC.
        /// Bind with controls.
        /// </summary>
        /// <value>OC of IScore.</value>
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

        /// <summary>
        /// Gets the undo move command.
        /// Bind with controls.
        /// </summary>
        /// <value>UndoMove as ICommand.</value>
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

        /// <summary>
        /// Gets the command for initialize.
        /// Bind with controls.
        /// </summary>
        /// <value>InitializeGame as ICommand.</value>
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

        /// <summary>
        /// Gets the command for commit top result.
        /// Bind with controls.
        /// </summary>
        /// <value>TopPlayerResultCommit as ICommand.</value>
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

        /// <summary>
        /// Gets the command for game's move method.
        /// Bind with controls.
        /// </summary>
        /// <value>MoveTile as ICommand.</value>
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

        /// <summary>
        /// The method handles initializeGameCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
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

        /// <summary>
        /// The method handles switchViewCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
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

        /// <summary>
        /// The method handles undoMoveCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
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

        /// <summary>
        /// The method handles moveTileCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
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

        /// <summary>
        /// The method handles topPlayerResultCommitCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
        private void HandelTopPlayerResultCommitCommand(object parameter)
        {
            this.ScoreboardInfo.Add(this.Moves, this.TopPlayerName);
            this.SincTopScoresWithsObservableScores(this.topScores, this.ScoreboardInfo.GetTopScores());
            this.OnPropertyChanged("TopScores");
            this.PageSwitcher.Switch(ViewSelector.HallOfFame);
        }

        /// <summary>
        /// The method set the way it all ends.
        /// </summary>
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

        /// <summary>
        /// The method synchronizes (adapts) the IGame Frame with OC of ITile for the needs of the WPF binding.
        /// </summary>
        /// <param name="tiles">The OC of ITiles.</param>
        /// <param name="frame">The IFrame.</param>
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

        /// <summary>
        /// The method synchronizes (adapts) the IList of IScore (result of IFrame.GetTopScores()) with OC of IScore for the needs of the WPF binding.
        /// </summary>
        /// <param name="observableScore">The OC of IScore.</param>
        /// <param name="scores">The IList of IScore.</param>
        private void SincTopScoresWithsObservableScores(ObservableCollection<IScore> observableScore, IList<IScore> scores)
        {
            observableScore.Clear();

            foreach (var score in scores)
            {
                observableScore.Add(score);
            }
        }
    }
}
