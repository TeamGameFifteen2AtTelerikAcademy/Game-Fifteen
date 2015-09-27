namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;

    class Program
    {
        static void Main()
        {
            GameFifteen.GenerateMatrix();
            GameFifteen.PrintWelcome();
            GameFifteen.PrintMatrix();
            GameFifteen.MainAlgorithm();
        }
    }
}