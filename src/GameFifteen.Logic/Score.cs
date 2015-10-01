namespace GameFifteen.Logic
{
    using System;

    using Contracts;

    public class Score : IScore, IComparable
    {
        private int moves;
        private string playerName;

        public Score(int moves, string playerName)
        {
            this.Moves = moves;
            this.PlayerNeme = playerName;
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }

            set
            {
                this.moves = value;
            }
        }

        public string PlayerNeme
        {
            get
            {
                return this.playerName;
            }

            set
            {
                this.playerName = value;
            }
        }

        public int CompareTo(object obj)
        {
            var otherScore = obj as IScore;

            if (otherScore == null)
            {
                throw new ArgumentException("Object does not implement IScore");
            }

            return this.Moves.CompareTo(otherScore.Moves);
        }
    }
}
