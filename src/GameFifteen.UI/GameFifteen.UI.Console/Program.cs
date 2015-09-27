namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;

    class Program
    {
        static void Main()
        {
            GameFifteen.ShuffleMatrix();
            GameFifteen.PrintWelcome();
            GameFifteen.PrintMatrix();
            GameFifteen.MainAlgorithm();
        }
    }
}