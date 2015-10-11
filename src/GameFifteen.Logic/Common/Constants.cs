// <copyright file="Constants.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Static class Constants
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Common
{
    using System;

    /// <summary>
    /// Public static class that holds all of the needed constants.
    /// </summary>
    public static class Constants
    {
        // Validator

        /// <summary>
        /// Constant for ArgumentName.
        /// </summary>
        public const string ArgumentName = "Argument name";

        /// <summary>
        /// Constant for CannotBeNullFormat.
        /// </summary>
        public const string CannotBeNullFormat = "{0} cannot be null!";

        /// <summary>
        /// Constant for MustBeAPositiveInteger.
        /// </summary>
        public const string MustBeAPositiveInteger = " must be a positive integer";

        /// <summary>
        /// Constant for MustBeEqualOrGreaterThanFormat.
        /// </summary>
        public const string MustBeEqualOrGreaterThanFormat = "{0} must be equal or greater than {1}";

        /// <summary>
        /// Constant for StringContainsOnlyLatinLetters.
        /// </summary>
        public const string StringContainsOnlyLatinLetters = "{0} must contain only latin letters";

        // Converter

        /// <summary>
        /// Constant for EnglishAlphabetLettersCount.
        /// </summary>
        public const int EnglishAlphabetLettersCount = 26;

        // Matrix

        /// <summary>
        /// Constant for HorizontalBorder.
        /// </summary>
        public const char HorizontalBorder = '-';

        /// <summary>
        /// Constant for VerticalBorder.
        /// </summary>
        public const string VerticalBorder = "|";

        /// <summary>
        /// The first part of the format for the tile representation.
        /// </summary>
        public const string TileStringFormatterLeft = "{0,";

        /// <summary>
        /// The second part of the format for the tile representation.
        /// </summary>
        public const string TileStringFormatterRight = "}";

        /// <summary>
        /// Constant for FrameDimensionMin.
        /// </summary>
        public const int FrameDimensionMin = 3;

        // Scoreboard

        /// <summary>
        /// Constant for Scoreboard.
        /// </summary>
        public const string Scoreboard = "Scoreboard:";

        /// <summary>
        /// Constant for ScoreboardIsEmpty.
        /// </summary>
        public const string ScoreboardIsEmpty = "Scoreboard is empty";

        /// <summary>
        /// Constant for ScoreboardFormat.
        /// </summary>
        public const string ScoreboardFormat = "{0}. {1} --> {2} moves";

        /// <summary>
        /// Constant for ScoreboardMaxCount.
        /// </summary>
        public const int ScoreboardMaxCount = 5;

        // GameInitializator

        /// <summary>
        /// Constant for TileTypeQuestion.
        /// </summary>
        public const string TileTypeQuestion = "What type of tiles would you like?\n\rNumber or Letter: ";

        /// <summary>
        /// Constant for PatternTypeQuestion.
        /// </summary>
        public const string PatternTypeQuestion = "What type of pattern would you like?\n\rClassic or Column: ";

        /// <summary>
        /// Constant for MoverTypesQuestion.
        /// </summary>
        public const string MoverTypesQuestion = "How would you like to move the tiles?\n\rClassic or RowCol: ";

        /// <summary>
        /// Constant for RowsQuestion.
        /// </summary>
        public const string RowsQuestion = "How many rows would you like? ";

        /// <summary>
        /// Constant for ColsQuestion.
        /// </summary>
        public const string ColsQuestion = "How many cols would you like? ";

        /// <summary>
        /// Constant for NegativeRowsCols.
        /// </summary>
        public const string NegativeRowsCols = "Board dimensions must be positive integers!";

        // User messages

        /// <summary>
        /// Constant for EnterCommandMessage.
        /// </summary>
        public const string EnterCommandMessage = "Enter a number to move: ";

        /// <summary>
        /// Constant for InvalidCommandMessage.
        /// </summary>
        public const string InvalidCommandMessage = "Invalid command!";

        /// <summary>
        /// Constant for InvalidMoveMessage.
        /// </summary>
        public const string InvalidMoveMessage = "Invalid move!";

        /// <summary>
        /// Constant for CongratulationsMessageFormat.
        /// </summary>
        public const string CongratulationsMessageFormat = "Congratulations! You won the game in {0} moves.";

        /// <summary>
        /// Constant for EnterNameMessage.
        /// </summary>
        public const string EnterNameMessage = "Please, enter your name for the top scoreboard: ";

        /// <summary>
        /// Constant for GoodbyeMessage.
        /// </summary>
        public const string GoodbyeMessage = "Good bye!";

        /// <summary>
        /// Constant for BoardSizeRestrictionInfo.
        /// </summary>
        public const string BoardSizeRestrictionInfo = "Board minimum size: 3x3";

        /// <summary>
        /// Constant for Welcome Message.
        /// </summary>
        public static readonly string WellcomeMessage =
            "Welcome to the game “15”. Please try to arrange the numbers sequentially." + Environment.NewLine +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game," + Environment.NewLine +
            "'exit' to quit the game, 'move' to move a tile and 'undo' to undo a move.";
    }
}
