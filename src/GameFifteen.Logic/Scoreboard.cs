using System.Text;
using GameFifteen.Logic.Common;

namespace GameFifteen.Logic
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    class Scoreboard
    {
        private readonly OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);

        public override string ToString()
        {
            if (this.scoreboard.Count == 0)
            {
                return Constants.ScoreboardIsEmpty;
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
