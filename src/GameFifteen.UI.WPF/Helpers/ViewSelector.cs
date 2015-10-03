namespace GameFifteen.UI.WPF.Helpers
{    
    using System.Windows.Controls;

    using Views;

    public static class ViewSelector
    {
        private static PreGameView preGame;
        
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
    }
}
