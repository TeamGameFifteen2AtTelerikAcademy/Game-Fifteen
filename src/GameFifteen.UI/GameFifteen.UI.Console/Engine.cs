namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;
    internal class Engine
    {
        // TODO: extract gameFifteen.MainAlgorithm logic here
        public void Run()
        {
            new GameFifteen().MainAlgorithm();
        }
    }
}