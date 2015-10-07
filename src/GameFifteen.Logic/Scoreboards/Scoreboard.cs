namespace GameFifteen.Logic.Scoreboards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Scoreboards.Contracts;

    public class Scoreboard : IScoreboard
    {
        protected IList<Score> TopScores = new List<Score>();

        public void Add(int moves, string playerName)
        {
            if (!this.IsInTopScores(moves))
            {
                return;
            }

            var newScore = new Score(moves, playerName);

            this.TopScores.Add(newScore);
            this.TopScores = this.TopScores
                .OrderBy(score => score.Moves)
                .Take(Constants.ScoreboardMaxCount)
                .ToList();
        }

        public bool IsInTopScores(int moves)
        {
            if (this.TopScores.Count() < Constants.ScoreboardMaxCount)
            {
                return true;
            }

            int mostMovesYet = this.TopScores.Last().Moves;

            if (moves < mostMovesYet)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (this.TopScores.Count == 0)
            {
                return Constants.ScoreboardIsEmpty + Environment.NewLine;
            }

            var result = new StringBuilder(Constants.Scoreboard);
            result.Append(Environment.NewLine);

            int index = 1;
            foreach (var score in this.TopScores)
            {
                result.AppendLine(string.Format(Constants.ScoreboardFormat, index, score.PlayerNeme, score.Moves));
                index++;
            }

            return result.ToString();
        }

        public IList<IScore> GetTopScores()
        {
            var publicTopScores = new List<IScore>();

            foreach (var score in this.TopScores)
            {
                publicTopScores.Add(new Score(score.Moves, score.PlayerNeme));
            }

            return publicTopScores;
        }
    }
}
