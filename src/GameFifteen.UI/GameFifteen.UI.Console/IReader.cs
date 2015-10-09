namespace GameFifteen.UI.Console
{
    public interface IReader
    {
        string ReadLine();

        string[] ParseInput(string input);
    }
}