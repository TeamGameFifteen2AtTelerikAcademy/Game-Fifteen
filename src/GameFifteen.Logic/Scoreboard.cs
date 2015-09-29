namespace GameFifteen.Logic
{
    using System;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    using Common;

    public class Scoreboard
    {
        public readonly OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);

        public bool IsGoesOnBoard(int moves)
        {
            foreach (var score in this.scoreboard)
            {
                if (moves < score.Key)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveLastScore()
        {
            if (scoreboard.Last().Value.Count > 0)
            {
                string[] values = new string[scoreboard.Last().Value.Count];
                scoreboard.Last().Value.CopyTo(values, 0);
                scoreboard.Last().Value.Remove(values.Last());
            }
            else
            {
                int[] keys = new int[scoreboard.Count];
                scoreboard.Keys.CopyTo(keys, 0);
                scoreboard.Remove(keys.Last());
            }
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
            foreach (var keyValuePair in this.scoreboard)
            {
                result.AppendLine(string.Format(Constants.ScoreboardFormat, index, keyValuePair.Value, keyValuePair.Key));
                index++;
            }

            return result.ToString();
        }
    }
}
