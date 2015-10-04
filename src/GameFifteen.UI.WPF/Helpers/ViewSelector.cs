namespace GameFifteen.UI.WPF.Helpers
{    
    using System.Windows.Controls;

    using Views;

    public static class ViewSelector
    {
        private static PreGameView preGame;
        private static ClassicGameVIew classicGame;
        
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
                    classicGame = new ClassicGameVIew();
                }

                return classicGame;
            }
        }
    }
}
