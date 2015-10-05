namespace GameFifteen.Logic.Memento
{
    using GameFifteen.Logic.Frames.Contracts;

    public interface IMemento
    {
        void SaveBoardState(IFrame board);

        void ClearHistory();

        IFrame Undo();
    }
}
