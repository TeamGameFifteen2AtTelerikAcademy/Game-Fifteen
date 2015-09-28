namespace GameFifteen.UI.Console
{
    using System;

    internal class Printer : IPrinter
    {
        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}