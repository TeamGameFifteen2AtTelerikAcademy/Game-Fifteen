namespace GameFifteen.UI.WPF.ViewModels
{
    using Commands;
    using Logic.Games;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Logic.Tiles.Contracts;
    using Logic.Tiles;
    using Logic.Frames.Contracts;
    using Logic.Frames;
    using Logic.Movers;
    using Logic.Movers.Contracts;
    using Logic.Games.Contracts;
    using Models;
    using System.Collections.ObjectModel;
    using Logic.Scoreboards.Contracts;
    using Logic.Scoreboards;

    public class ClassicGameViewModel : ViewModelBase
    {
        private GameWithPublicFrame game;
        private IScoreboard scoreboard;
        private TileFactory tileFactory;
        private FrameBuilder frameBuilder;
        private FrameDirector director;
        private IMover mover;
        private IFrame frame;
        private IFrame targetFrame;
        private int rows;
        private int cols;
        private int moves;

        private ObservableCollection<TileModel> tiles;

        public ObservableCollection<TileModel> Tiles
        {
            get
            {
                if (this.tiles == null)
                {
                    this.tiles = new ObservableCollection<TileModel>();
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
            this.tileFactory = new NumberTileFactory();
            this.frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            this.director = new FrameDirector(frameBuilder)
                ;
            int rows = 4;
            int cols = 4;

            this.targetFrame = director.ConstructFrame(rows, cols);

            this.mover = new RowColMover();
            this.game = new GameWithPublicFrame(targetFrame, mover);
            this.game.Shuffle();

            this.scoreboard = new Scoreboard();

            this.frame = this.game.Frame;
            this.Rows = this.frame.Rows;
            this.Cols = this.frame.Cols;
            this.Moves = 0;
            this.tiles = new ObservableCollection<TileModel>();

            this.SincFrameTilesWithObservableTiles(this.tiles, this.frame);
            this.OnPropertyChanged("Tiles");
        }

        private void HandleMoveTileCommand(object parameter)
        {
            this.Moves += 1;
            var button = parameter as Button;
            var label = button.Content.ToString();

            this.game.Move(label);

            this.SincFrameTilesWithObservableTiles(this.tiles, this.frame);
            this.OnPropertyChanged("Tiles");
            this.OnPropertyChanged("Moves");

            if (this.game.IsSolved)
            {
                MessageBox.Show(string.Format("Success - solved with {0} moves!!", this.Moves));
            }
        }

        private void SincFrameTilesWithObservableTiles(ObservableCollection<TileModel> tiles, IFrame frame)
        {
            this.tiles.Clear();

            for (int row = 0; row < frame.Rows; row++)
            {
                for (int col = 0; col < frame.Cols; col++)
                {
                    int index = this.CalculateTileIndex(row, col, frame.Cols);
                    tiles.Add( new TileModel()
                    {
                        Label = frame.Tiles[row, col].Label,
                        Row = row,
                        Col = col
                    });
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
