namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers;
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
            int rows = this.ChooseInteger(Constants.RowsQuestion);
            int cols = this.ChooseInteger(Constants.ColsQuestion);

            var frame = director.ConstructFrame(rows, cols);

            // TODO: add method for choosing mover when there are multiple movers implemented
            var mover = new RowColMover();

            return new Game(frame, mover);
        }

        private TileFactory ChooseTiles()
        {
            TileFactory tileFactory;
            var tileType = this.ChooseType<TileType>(Constants.TileTypeQuestion);
            switch (tileType)
            {
                case TileType.Letter: tileFactory = new LetterTileFactory();
                    break;
                default: tileFactory = new NumberTileFactory();
                    break;
            }

            return tileFactory;
        }

        private FrameBuilder ChoosePattern(TileFactory tileFactory)
        {
            FrameBuilder frameBuilder;
            var patterType = this.ChooseType<PatternType>(Constants.PatternTypeQuestion);

            switch (patterType)
            {
                case PatternType.Column: frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
                    break;
                default: frameBuilder =new ClassicPatternFrameBuilder(tileFactory);
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