namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Movers.Contracts;
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;

    internal class GameInitializator
    {
        private readonly IPrinter printer;

        private readonly IReader reader;

        public GameInitializator(IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(printer);
            Validator.ValidateIsNotNull(reader);

            this.printer = printer;
            this.reader = reader;
        }

        public IGame Initialize()
        {
            var tileFactory = this.ChooseTiles();
            var frameBuilder = this.ChoosePattern(tileFactory);
            var director = new FrameDirector(frameBuilder);
         //  this.printer.PrintLine(Constants.BoardSizeRestrictionInfo);
            int rows = this.ChooseInteger(Constants.BoardSizeRestrictionInfo + Environment.NewLine +  Constants.RowsQuestion);
            int cols = this.ChooseInteger(Constants.ColsQuestion);
            IFrame frame;

            try
            {
                frame = director.ConstructFrame(rows, cols);
            }
            catch(OverflowException )
            {               
                this.printer.PrintLine(Constants.NegativeRowsCols);
                this.printer.PrintLine(Constants.BoardSizeRestrictionInfo);
                frame = director.ConstructFrame(Constants.FrameDimensionMin, Constants.FrameDimensionMin);

            }

            var mover = this.ChooseMover();

            return new Game(frame, mover);
        }

        private TileFactory ChooseTiles()
        {
            TileFactory tileFactory;
            var tileType = this.ChooseType<TileTypes>(Constants.TileTypeQuestion);
            switch (tileType)
            {
                case TileTypes.Letter: tileFactory = new LetterTileFactory();
                    break;
                default: tileFactory = new NumberTileFactory();
                    break;
            }

            return tileFactory;
        }

        private IMover ChooseMover()
        {
            IMover mover;
            var moverType = this.ChooseType<MoverTypes>(Constants.MoverTypesQuestion);

            switch (moverType)
            {
                case MoverTypes.RowCol: mover = new RowColMover();
                    break;
                default: mover = new ClassicMover();
                    break;
            }

            return mover;
        }

        private FrameBuilder ChoosePattern(TileFactory tileFactory)
        {
            FrameBuilder frameBuilder;
            var patterType = this.ChooseType<PatternTypes>(Constants.PatternTypeQuestion);

            switch (patterType)
            {
                case PatternTypes.Column: frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
                    break;
                default: frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
                    break;
            }

            return frameBuilder;
        }

        private T ChooseType<T>(string message) where T : struct
        {
            T result;
            do
            {
                this.printer.Print(message);
            }
            while (!Enum.TryParse(this.reader.ReadLine(), true, out result));

            return result;
        }

        private int ChooseInteger(string message)
        {
            int integer;
            do
            {
                this.printer.Print(message);
            }
            while (!int.TryParse(this.reader.ReadLine(), out integer));

            return integer;
        }
    }
}