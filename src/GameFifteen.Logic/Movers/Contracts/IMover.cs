// <copyright file="IMover.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IMover.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Movers.Contracts
{
    using GameFifteen.Logic.Frames.Contracts;

    /// <summary>
    /// Interface for IMover.
    /// </summary>
    public interface IMover
    {
        /// <summary>
        /// Moves tile in frame by given tile label. And returns if move is successful.
        /// </summary>
        /// <param name="tileLabel">Tile of type ITile.</param>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <returns>True or false.</returns>
        bool Move(string tileLabel, IFrame frame);

        /// <summary>
        /// Shuffles the frame.
        /// </summary>
        /// <param name="frame">Frame to  be shuffled.</param>
        void Shuffle(IFrame frame);
    }
}
