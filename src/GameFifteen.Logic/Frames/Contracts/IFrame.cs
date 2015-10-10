// <copyright file="IFrame.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IFrame.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames.Contracts
{
    using Tiles.Contracts;

    /// <summary>
    /// Interface for IFrame.
    /// </summary>
    public interface IFrame
    {
        /// <summary>
        /// Gets two-dimensional array of ITile.
        /// </summary>
        /// <value>Two dimensional array of Tile.</value>
        ITile[,] Tiles { get; }

        /// <summary>
        /// Gets number of rows of the Tiles.
        /// </summary>
        /// <value>Frame rows.</value>
        int Rows { get; }

        /// <summary>
        /// Gets of columns of the Tiles.
        /// </summary>
        /// <value>Frame columns.</value>
        int Cols { get; }

        /// <summary>
        /// The method should return deep copy of itself.
        /// </summary>
        /// <returns>IFrame deep copy.</returns>
        IFrame Clone();

        /// <summary>
        /// The method should determinate how to compare two IFrames.
        /// </summary>
        /// <param name="other">Accepts IFrame to be compared with.</param>
        /// <returns>Returns boolean value.</returns>
        bool Equals(IFrame other);
    }
}
