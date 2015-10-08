namespace GameFifteen.UI.WPF.Helpers
{
    using System.Windows.Controls;

    using Views;

    public static class ViewSelector
    {
        private static PreGameView preGame;
        private static GameView classicGame;
        private static GameSettingsView gameSetings;
        private static AboutView about;
        private static HallOfFameView hawOfFame;
        private static CompletedGameView completeGame;
        private static CompletedWithTopScoreView completeTopScoreGame;

        public static UserControl CompleteTopScoreGame
        {
            get
            {
                if (completeTopScoreGame == null)
                {
                    completeTopScoreGame = new CompletedWithTopScoreView();
                }

                return completeTopScoreGame;
            }
        }

        public static UserControl JustCompletedGame
        {
            get
            {
                if (completeGame == null)
                {
                    completeGame = new CompletedGameView();
                }

                return completeGame;
            }
        }

        public static UserControl HallOfFame
        {
            get
            {
                if (hawOfFame == null)
                {
                    hawOfFame = new HallOfFameView();
                }

                return hawOfFame;
            }
        }

        public static UserControl About
        {
            get
            {
                if (about == null)
                {
                    about = new AboutView();
                }

                return about;
            }
        }

        public static UserControl PreGame
        {
            get
            {
                if (preGame == null)
                {
                    preGame = new PreGameView();
                }

                return preGame;
            }
        }

        public static UserControl Game
        {
            get
            {
                if (classicGame == null)
                {
                    classicGame = new GameView();
                }

                return classicGame;
            }
        }

        public static UserControl GameSettings
        {
            get
            {
                if (gameSetings == null)
                {
                    gameSetings = new GameSettingsView();
                }

                return gameSetings;
            }
        }
    }
}