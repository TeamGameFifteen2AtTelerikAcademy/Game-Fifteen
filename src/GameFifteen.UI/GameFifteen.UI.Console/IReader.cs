namespace GameFifteen.UI.Console
{
    internal interface IReader
    {
        string ReadLine();

        string[] ParseInput(string input);
    }
}