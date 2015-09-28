namespace GameFifteen.UI.Console
{
    internal class Program
    {
        public static void Main()
        {
            var printer = new Printer();

            new Engine(printer).Run();
        }
    }
}