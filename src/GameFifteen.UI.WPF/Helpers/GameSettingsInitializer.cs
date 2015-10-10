// <copyright file="GameSettingsInitializer.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// GameSettingsInitializer class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Helpers
{
    using System;

    using Logic.Frames;
    using Logic.Frames.Contracts;
    using Logic.Movers;
    using Logic.Movers.Contracts;
    using Logic.Tiles;
    using Logic.Tiles.Contracts;

    /// <summary>
    /// GameSettingsInitializer class.
    /// </summary>
    public class GameSettingsInitializer
    {
        /// <summary>
        /// Initializes a new instance of the GameSettingsInitializer class.
        /// </summary>
        public GameSettingsInitializer()
        {
        }

        /// <summary>
        /// The method choose TileFactory by given string.
        /// </summary>
        /// <param name="selecterdTileType">Tile factory type.</param>
        /// <returns>New TileFactory.</returns>
        public TileFactory ChooseTiles(string selecterdTileType)
        {
            TileFactory tileFactory;

            TileTypes tileType = (TileTypes)Enum.Parse(typeof(TileTypes), selecterdTileType, true);

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
        /// The method choose IMover by given string.
        /// </summary>
        /// <param name="selectedMover">IMover type.</param>
        /// <returns>New TileFactory.</returns>
        public IMover ChooseMover(string selectedMover)
        {
            IMover mover;

            MoverTypes moverType = (MoverTypes)Enum.Parse(typeof(MoverTypes), selectedMover, true);

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
        /// The method choose FrameBuilder.
        /// </summary>
        /// <param name="tileFactory">The Tile factory.</param>
        /// <param name="selectedPattern">The selected pattern.</param>
        /// <returns>New FrameBuilder.</returns>
        public FrameBuilder ChoosePattern(TileFactory tileFactory, string selectedPattern)
        {
            FrameBuilder frameBuilder;
            PatternTypes patterType = (PatternTypes)Enum.Parse(typeof(PatternTypes), selectedPattern, true);

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
    }
}