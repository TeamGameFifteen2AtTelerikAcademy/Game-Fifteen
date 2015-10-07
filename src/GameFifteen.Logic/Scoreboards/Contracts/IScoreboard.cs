using System.Collections.Generic;

namespace GameFifteen.Logic.Scoreboards.Contracts
{
    public interface IScoreboard
    {
        bool IsInTopScores(int moves);

        void Add(int moves, string playerNmae);

        IList<IScore> GetTopScores();
    }
}
