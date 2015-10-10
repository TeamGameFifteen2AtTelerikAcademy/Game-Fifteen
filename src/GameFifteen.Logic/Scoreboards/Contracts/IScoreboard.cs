// <copyright file="IScoreboard.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IScoreboard.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Scoreboards.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for IScoreboard.
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Returns if the given moves count is top score.
        /// </summary>
        /// <param name="moves">Moves to check.</param>
        /// <returns>True or false.</returns>
        bool IsInTopScores(int moves);

        /// <summary>
        /// Adds score to top scores if is top score.
        /// </summary>
        /// <param name="moves">Moves count.</param>
        /// <param name="playerNmae">Player's name.</param>
        void Add(int moves, string playerNmae);

        /// <summary>
        /// Gets tops scores as IList of IScores.
        /// </summary>
        /// <returns>IList of IScores.</returns>
        IList<IScore> GetTopScores();
    }
}
