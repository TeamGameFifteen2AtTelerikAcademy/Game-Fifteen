// <copyright file="IScore.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IScore.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Scoreboards.Contracts
{
    /// <summary>
    /// Interface for IScore.
    /// </summary>
    public interface IScore
    {
        /// <summary>
        /// Gets IScore's moves.
        /// </summary>
        /// <value>Number of moves.</value>
        int Moves { get; }

        /// <summary>
        /// Gets IScore's moves.
        /// </summary>
        /// <value>Number of moves.</value>
        string PlayerNeme { get; }
    }
}