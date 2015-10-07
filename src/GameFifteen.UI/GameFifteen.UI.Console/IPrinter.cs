namespace GameFifteen.UI.Console
{
    internal interface IPrinter
    {
        void Print(object obj);

        void PrintLine(object obj);

        void ClearBoard();

        void SetCursorTopBoard();
        void ClearLine();
        void SetCursorBottomBoard();
        void ClearMessages();
    }
}