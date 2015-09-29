using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GameFifteen.Logic.Contracts;
using GameFifteen.Logic.Common;

namespace GameFifteen.Logic
{
    public class Scoreboard : IScoreboard
    {
        private List<IScore> scoreboard;

        public Scoreboard()
        {
            this.scoreboard = new List<IScore>();
        }

        public void Add(int moves, string playerName)
        {
            if (!IsInTopScores(moves))
            {
                return; //TODO: DO SOMETHING ELSE
            }

            var newScore = new Score(moves, playerName);

            this.scoreboard.Add(newScore);
            this.scoreboard = this.scoreboard
                .OrderBy(score => score.Moves)
                .Take(Constants.ScoreboardMaxCount)
                .ToList();
        }

        public bool IsInTopScores(int moves)
        {
            if (this.scoreboard.Count() < Constants.ScoreboardMaxCount)
            {
                return true;
            }

            int mostMovesYet = this.scoreboard.Last().Moves;

            if (moves < mostMovesYet)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (this.scoreboard.Count == 0)
            {
                return Constants.ScoreboardIsEmpty + Environment.NewLine;
            }

            var result = new StringBuilder(Constants.Scoreboard);
            result.Append(Environment.NewLine);

            int index = 1;
            foreach (var score in this.scoreboard)
            {
                result.AppendLine(string.Format(Constants.ScoreboardFormat, index, score.PlayerNeme, score.Moves));
                index++;
            }

            return result.ToString();
        }
    }
}
