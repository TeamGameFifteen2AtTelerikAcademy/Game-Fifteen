﻿namespace GameFifteen.Logic.Common
{
    using System;

    public static class Constants
    {
        // Validator
        public const string ArgumentName = "Argument name";
        public const string CannotBeNullFormat = "{0} cannot be null!";

        // Matrix
        public const string HorizontalBorder = " -------------";
        public const string VerticalBorder = "|";

        // Scoreboard
        public const string Scoreboard = "Scoreboard:";
        public const string ScoreboardIsEmpty = "Scoreboard is empty";
        public const string ScoreboardFormat = "{0}. {1} --> {2} moves";
        public const int ScoreboardMaxCount = 5;

        // GameInitializator
        public const string TileTypeQuestion = "What type of tiles would you like?\n\rNumber or Letter: ";
        public const string PatternTypeQuestion = "What type of pattern would you like?\n\rClassic or Column: ";
        public const string MoverTypesQuestion = "How would you like to move the tiles?\n\rClassic or RowCol: ";
        public const string RowsQuestion = "How many rows would you like? ";
        public const string ColsQuestion = "How many cols would you like? ";

        // User messages
        public const string EnterCommandMessage = "Enter a number to move: ";
        public const string InvalidCommandMessage = "Invalid command!";
        public const string InvalidMoveMessage = "Invalid move!";
        public const string CongratulationsMessageFormat = "Congratulations! You won the game in {0} moves.";
        public const string EnterNameMessage = "Please, enter your name for the top scoreboard: ";
        public const string GoodbyeMessage = "Good bye!";
        public static readonly string WellcomeMessage =
            "Welcome to the game “15”. Please try to arrange the numbers sequentially." + Environment.NewLine +
            "Use 'Top' to view the top scoreboard, 'Restart' to start a new game and" + Environment.NewLine +
            "'Exit' to quit the game.";

        // Convertor
        public const int EnglishAlphabetLettersCount = 26;
    }
}
