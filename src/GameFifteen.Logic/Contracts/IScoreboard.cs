namespace GameFifteen.Logic.Contracts
{
    public interface IScoreboard
    {
        bool IsInTopScores(int moves);

        void Add(int moves, string playerNmae);
    }
}
