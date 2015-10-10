// <copyright file="IMemento.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IMemento.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Memento
{
    using GameFifteen.Logic.Frames.Contracts;

    /// <summary>
    /// Interface for IMemento.
    /// </summary>
    public interface IMemento
    {
        /// <summary>
        /// Saves board state.
        /// </summary>
        /// <param name="board">Board of type IFrame.</param>
        void SaveBoardState(IFrame board);

        /// <summary>
        /// Clears the history.
        /// </summary>
        void ClearHistory();

        /// <summary>
        /// Returns last saved board state.
        /// </summary>
        /// <returns>Returns IFrame.</returns>
        IFrame Undo();
    }
}
