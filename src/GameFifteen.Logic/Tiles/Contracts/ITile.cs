// <copyright file="ITile.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ITile.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles.Contracts
{
    /// <summary>
    /// ITile interface.
    /// </summary>
    public interface ITile
    {
        /// <summary>
        /// Gets ITile's Id.
        /// </summary>
        /// <value>TIle's Id integer.</value>
        int Id { get; }

        /// <summary>
        /// Gets ITile's Label.
        /// </summary>
        /// <value>TIle's Label string.</value>
        string Label { get; }
    }
}
