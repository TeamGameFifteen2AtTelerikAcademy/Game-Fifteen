﻿namespace GameFifteen.UI.WPF.ViewModels
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

    public class GameViewModel : ViewModelBase
    {
        private IGame game;
        private IScoreboard scoreboard;
        private TileFactory tileFactory;
        private FrameBuilder frameBuilder;
        private FrameDirector director;
        private GameSettingsInicialisator settingsInicializator;
        private IMover mover;
        private IFrame targetFrame;
        private int rows;
        private int cols;
        private int moves;

        private ObservableCollection<ITile> tiles;

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

        private ICommand initializeGameCommand;
        private ICommand moveTileCommand;

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
            this.tileFactory = settingsInicializator.ChooseTiles(SettingsKeeper.Tile);
            this.mover = settingsInicializator.ChooseMover(SettingsKeeper.Mover);
            this.frameBuilder = settingsInicializator.ChoosePattern(this.tileFactory, SettingsKeeper.Pattern);
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");

            this.director = new FrameDirector(frameBuilder);           

            var newFrame = director.ConstructFrame(rows, cols);

            this.game = new Game(newFrame, mover);
            this.game.Shuffle();

            this.scoreboard = new Scoreboard();            
            this.Moves = 0;

            this.tiles = new ObservableCollection<ITile>();

            this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("Rows");
            this.OnPropertyChanged("Cols");
        }

        private void HandleMoveTileCommand(object parameter)
        {
            this.Moves += 1;
            var button = parameter as Button;
            var label = button.Content.ToString();

            this.game.Move(label);

            this.SincFrameTilesWithObservableTiles(this.tiles, this.game.Frame);
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("Moves");

            if (this.game.IsSolved)
            {
                MessageBox.Show(string.Format("Success - solved with {0} moves!!", this.Moves));
            }
        }

        private void SincFrameTilesWithObservableTiles(ObservableCollection<ITile> tiles, IFrame frame)
        {
            this.tiles.Clear();

            for (int row = 0; row < frame.Rows; row++)
            {
                for (int col = 0; col < frame.Cols; col++)
                {
                   // int index = this.CalculateTileIndex(row, col, frame.Cols);
                    tiles.Add( frame.Tiles[row, col]);
                }
            }
        }

        private int CalculateTileIndex(int tileRow, int tileCol, int frameCols)
        {
            int index = (tileCol * frameCols) + tileCol;
            return index;
        }
    }
}
