namespace GameFifteen.UI.Console
{
    using System;

    internal class Printer : IPrinter
    {
        private int currentLineCursor;

        public void Print(object obj)
        {
            Console.Write(obj);
        }

        public void PrintLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void SetCursorTopBoard()
        {
            Console.SetCursorPosition(0, 1);
        }

        public void SetCursorBottomBoard()
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }

        public void ClearBoard()
        {
            Console.Clear();
        }

        public void ClearLine()
        {
            this.currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void ClearMessages()
        {
            this.currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
           
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}