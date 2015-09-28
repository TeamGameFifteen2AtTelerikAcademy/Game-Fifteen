namespace GameFifteen.UI.Console
{
    using System;

    class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}