namespace GameFifteen.UI.WPF.Helpers
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