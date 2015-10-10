// <copyright file="IGame.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IGame.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Games.Contracts
{
    using GameFifteen.Logic.Frames.Contracts;

    /// <summary>
    /// Interface for IGame.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Gets a value indicating whether if the game is solved.
        /// </summary>
        /// <value>True or false.</value>
        bool IsSolved { get; }

        /// <summary>
        /// Gets or sets the game frame of type IFrame.
        /// </summary>
        /// <value>Frame of type IFrame.</value>
        IFrame Frame { get; set; }

        /// <summary>
        /// Gets the game initial frame of type IFrame.
        /// </summary>
        /// <value>Frame of type IFrame.</value>
        IFrame FramePrototype { get; }

        /// <summary>
        /// Move the tile in the frame and returns if the move is possible.
        /// </summary>
        /// <param name="tileLabel">Label of the tile string format.</param>
        /// <returns>True or false.</returns>
        bool Move(string tileLabel);

        /// <summary>
        /// Shuffles the initial game frame.
        /// </summary>
        void Shuffle();
    }
}
