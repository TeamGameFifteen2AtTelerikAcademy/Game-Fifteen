namespace GameFifteen.UI.WPF.Helpers
{
    using Logic.Scoreboards.Contracts;
    using Logic.Games.Contracts;

    public static class SettingsKeeper
    {
        private static string rows;
        private static string cols;
        private static string tile;
        private static string pattern;
        private static string mover;
        private static IGame game;
        private static IScoreboard scoreBoard;
        private static int currentTotalMoves;
        
        public static string Rows
        {
            get
            {
                if (rows == null)
                {
                    rows = "4";
                }

                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public static string Cols
        {
            get
            {
                if (cols == null)
                {
                    cols = "4";
                }

                return cols;
            }

            set
            {
                cols = value;
            }
        }

        public static string Tile
        {
            get
            {
                if (tile == null)
                {
                    tile = "Number";
                }

                return tile;
            }

            set
            {
                tile = value;
            }
        }

        public static string Pattern
        {
            get
            {
                if (pattern == null)
                {
                    pattern = "Classic";
                }

                return pattern;
            }

            set
            {
                pattern = value;
            }
        }

        public static string Mover
        {
            get
            {
                if (mover == null)
                {
                    mover = "Classic";
                }


                return mover;
            }

            set
            {
                mover = value;
            }
        }

        public static IGame Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
            }
        }

        public static IScoreboard ScoreBoard
        {
            get
            {
                return scoreBoard;
            }

            set
            {
                scoreBoard = value;
            }
        }

        public static int CurrentTotalMoves
        {
            get
            {
                if (currentTotalMoves == null)
                {
                    currentTotalMoves = 0;
                }

                return currentTotalMoves;
            }

            set
            {
                currentTotalMoves = value;
            }
        }
    }
}
