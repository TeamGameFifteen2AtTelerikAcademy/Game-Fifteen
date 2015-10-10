// <copyright file="GameInitializator.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// GameInitializator class.
// </summary>
// <author>GameFifteen2Team</author>

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

    /// <summary>
    /// Game Initializer class.
    /// </summary>
    internal class GameInitializator
    {
        /// <summary>
        /// Holds the IPrinter.
        /// </summary>
        private readonly IPrinter printer;

        /// <summary>
        /// Holds the IReader.
        /// </summary>
        private readonly IReader reader;

        /// <summary>
        /// Initializes a new instance of the GameInitializator class.
        /// </summary>
        /// <param name="printer">The IPrinter.</param>
        /// <param name="reader">The IReader.</param>
        public GameInitializator(IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(printer);
            Validator.ValidateIsNotNull(reader);

            this.printer = printer;
            this.reader = reader;
        }

        /// <summary>
        /// The method initialize IGame.
        /// </summary>
        /// <returns>New IGame.</returns>
        public IGame Initialize()
        {
            var tileFactory = this.ChooseTiles();
            var frameBuilder = this.ChoosePattern(tileFactory);
            var director = new FrameDirector(frameBuilder);
            int rows = this.ChooseInteger(Constants.BoardSizeRestrictionInfo + Environment.NewLine + Constants.RowsQuestion);
            int cols = this.ChooseInteger(Constants.ColsQuestion);

            var frame = director.ConstructFrame(rows, cols);
            if (frame.Rows != rows || frame.Cols != cols)
            {
                this.printer.PrintLine(Constants.NegativeRowsCols);
                this.printer.PrintLine(Constants.BoardSizeRestrictionInfo);
            }

            var mover = this.ChooseMover();

            return new Game(frame, mover);
        }

        /// <summary>
        /// The method selects Tiles factory type.
        /// </summary>
        /// <returns>New TileFactory.</returns>
        private TileFactory ChooseTiles()
        {
            TileFactory tileFactory;
            var tileType = this.ChooseType<TileTypes>(Constants.TileTypeQuestion);
            switch (tileType)
            {
                case TileTypes.Letter:
                    tileFactory = new LetterTileFactory();
                    break;
                default:
                    tileFactory = new NumberTileFactory();
                    break;
            }

            return tileFactory;
        }

        /// <summary>
        /// The method selects IMover type.
        /// </summary>
        /// <returns>New IMover.</returns>
        private IMover ChooseMover()
        {
            IMover mover;
            var moverType = this.ChooseType<MoverTypes>(Constants.MoverTypesQuestion);

            switch (moverType)
            {
                case MoverTypes.RowCol:
                    mover = new RowColMover();
                    break;
                default:
                    mover = new ClassicMover();
                    break;
            }

            return mover;
        }

        /// <summary>
        /// The method selects FrameBuilder type.
        /// </summary>
        ///  /// <param name="tileFactory">The Tile factory.</param>
        /// <returns>New FrameBuilder.</returns>
        private FrameBuilder ChoosePattern(TileFactory tileFactory)
        {
            FrameBuilder frameBuilder;
            var patterType = this.ChooseType<PatternTypes>(Constants.PatternTypeQuestion);

            switch (patterType)
            {
                case PatternTypes.Column:
                    frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
                    break;
                default:
                    frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
                    break;
            }

            return frameBuilder;
        }

        /// <summary>
        /// The method choose type by readers input.
        /// </summary>
        /// <typeparam name="T">Struct of type T.</typeparam>
        /// <param name="message">String message.</param>
        /// <returns>Object of type struct.</returns>
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

        /// <summary>
        /// The method choose integer by readers input.
        /// </summary>
        /// <param name="message">String message.</param>
        /// <returns>Selected integer.</returns>
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