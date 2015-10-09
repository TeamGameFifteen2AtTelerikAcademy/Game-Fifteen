namespace GameFifteen.UI.Console
{
    public interface IPrinter
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