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
        private IList<Score> topScores = new List<Score>();

        public void Add(int moves, string playerName)
        {
            if (!this.IsInTopScores(moves))
            {
                return;
            }

            var newScore = new Score(moves, playerName);

            this.topScores.Add(newScore);
            this.topScores = this.topScores
                .OrderBy(score => score.Moves)
                .Take(Constants.ScoreboardMaxCount)
                .ToList();
        }

        public bool IsInTopScores(int moves)
        {
            if (this.topScores.Count() < Constants.ScoreboardMaxCount)
            {
                return true;
            }

            int mostMovesYet = this.topScores.Last().Moves;

            if (moves < mostMovesYet)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (this.topScores.Count == 0)
            {
                return Constants.ScoreboardIsEmpty + Environment.NewLine;
            }

            var result = new StringBuilder(Constants.Scoreboard);
            result.Append(Environment.NewLine);

            int index = 1;
            foreach (var score in this.topScores)
            {
                result.AppendLine(string.Format(Constants.ScoreboardFormat, index, score.PlayerNeme, score.Moves));
                index++;
            }

            return result.ToString();
        }

        protected class Score
        {
            public Score(int moves, string playerName)
            {
                this.Moves = moves;
                this.PlayerNeme = playerName;
            }

            public int Moves { get; private set; }

            public string PlayerNeme { get; private set; }
        }
    }
}