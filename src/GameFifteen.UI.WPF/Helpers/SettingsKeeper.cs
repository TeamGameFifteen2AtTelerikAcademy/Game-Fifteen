// <copyright file="SettingsKeeper.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// SettingsKeeper class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Helpers
{
    using Logic.Games.Contracts;
    using Logic.Scoreboards.Contracts;

    /// <summary>
    /// SettingsKeeper class.
    /// Holds game settings.
    /// </summary>
    public static class SettingsKeeper
    {
        /// <summary>
        /// Holds settings rows.
        /// </summary>
        private static string rows;

        /// <summary>
        /// Holds settings columns.
        /// </summary>
        private static string cols;

        /// <summary>
        /// Holds settings tile type.
        /// </summary>
        private static string tileType;

        /// <summary>
        /// Holds settings pattern.
        /// </summary>
        private static string pattern;

        /// <summary>
        /// Holds settings mover.
        /// </summary>
        private static string mover;

        /// <summary>
        /// Holds settings IGame.
        /// </summary>
        private static IGame game;

        /// <summary>
        /// Holds settings IScoreboard.
        /// </summary>
        private static IScoreboard scoreBoard;

        /// <summary>
        /// Gets or sets settings  rows.
        /// </summary>
        /// <value>Rows of type integer.</value>
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

        /// <summary>
        /// Gets or sets settings  columns.
        /// </summary>
        /// <value>Cols of type integer.</value>
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

        /// <summary>
        /// Gets or sets settings tileType.
        /// </summary>
        /// <value>Tile of type string.</value>
        public static string Tile
        {
            get
            {
                if (tileType == null)
                {
                    tileType = "Number";
                }

                return tileType;
            }

            set
            {
                tileType = value;
            }
        }

        /// <summary>
        /// Gets or sets settings pattern.
        /// </summary>
        /// <value>Pattern of type string.</value>
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

        /// <summary>
        /// Gets or sets settings mover.
        /// </summary>
        /// <value>Mover of type string.</value>
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

        /// <summary>
        /// Gets or sets settings game.
        /// </summary>
        /// <value>Game of type IGame.</value>
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

        /// <summary>
        /// Gets or sets settings scoreBoard.
        /// </summary>
        /// <value>ScoreBoard of type IScoreboard.</value>
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
    }
}