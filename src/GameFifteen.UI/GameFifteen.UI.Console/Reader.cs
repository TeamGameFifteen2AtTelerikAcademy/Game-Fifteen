namespace GameFifteen.UI.Console
{
    using System;

    internal class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}