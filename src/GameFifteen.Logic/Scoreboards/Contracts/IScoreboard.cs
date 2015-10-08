namespace GameFifteen.Logic.Scoreboards.Contracts
{
    using System.Collections.Generic;

    public interface IScoreboard
    {
        bool IsInTopScores(int moves);

        void Add(int moves, string playerNmae);

        IList<IScore> GetTopScores();
    }
}
