namespace GameFifteen.UI.WPF.Helpers
{    
    using System.Windows.Controls;

    using Views;

    public static class ViewSelector
    {
        private static PreGameView preGame;
        private static GameView classicGame;
        private static GameSettingsView gameSetings;


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

        public static UserControl ClassicGame
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
