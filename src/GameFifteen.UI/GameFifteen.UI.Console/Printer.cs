namespace GameFifteen.UI.Console
{
    using System;

    internal class Printer : IPrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}