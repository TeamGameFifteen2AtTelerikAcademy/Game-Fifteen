namespace GameFifteen.UI.WPF.Helpers
{
    using System;

    using Logic.Frames;
    using Logic.Frames.Contracts;
    using Logic.Movers;
    using Logic.Movers.Contracts;
    using Logic.Tiles;
    using Logic.Tiles.Contracts;

    public class GameSettingsInicialisator
    {
        public GameSettingsInicialisator()
        {
        }

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