namespace GameFifteen.Logic.Common
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

        // User messages
        public const string EnterCommandMessage = "Enter a number to move: ";
        public const string InvalidCommandMessage = "Invalid command!";
        public const string InvalidMoveMessage = "Invalid move!";
        public const string CongratulationsMessageFormat = "Congratulations! You won the game in {0} moves.";
        public const string EnterNameMessage = "Please, enter your name for the top scoreboard: ";
        public const string GoodbyeMessage = "Good bye!";
        public static readonly string WellcomeMessage =
            "Welcome to the game “15”. Please try to arrange the numbers sequentially." + Environment.NewLine +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and" + Environment.NewLine +
            "'exit' to quit the game.";

    }
}