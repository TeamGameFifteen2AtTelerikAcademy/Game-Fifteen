// <copyright file="Score.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class Score.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic
{
    using GameFifteen.Logic.Scoreboards.Contracts;

    /// <summary>
    /// The class represents the model of the Score.
    /// </summary>
    public class Score : IScore
    {
        /// <summary>
        /// Initializes a new instance of the Score class.
        /// </summary>
        /// <param name="moves">Score's moves.</param>
        /// <param name="playerName">Score's player name.</param>
        public Score(int moves, string playerName)
        {
            this.Moves = moves;
            this.PlayerNeme = playerName;
        }

        /// <summary>
        /// Gets IScore's moves.
        /// </summary>
        /// <value>Number of moves.</value>
        public int Moves { get; private set; }

        /// <summary>
        /// Gets IScore's moves.
        /// </summary>
        /// <value>Number of moves.</value>
        public string PlayerNeme { get; private set; }
    }
}
