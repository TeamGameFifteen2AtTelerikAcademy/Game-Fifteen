namespace GameFifteen.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
        
    using Common;
    using Contracts;

    public class Scoreboard : IScoreboard
    {
        private IList<IScore> topScores;

        public Scoreboard()
        {
            this.TopScores = new List<IScore>();
        }  

        private IList<IScore> TopScores
        {
            get
            {
                return this.topScores;
            }

            set
            {
                this.topScores = value;
            }
        }

        public void Add(int moves, string playerName)
        {
            if (!this.IsInTopScores(moves))
            {
                return; // TODO: DO SOMETHING ELSE
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
    }
}
