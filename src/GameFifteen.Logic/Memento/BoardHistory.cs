// <copyright file="BoardHistory.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// BoardHistory class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Memento
{
    using System.Collections.Generic;
    using GameFifteen.Logic.Frames.Contracts;

    /// <summary>
    /// The class represents the model of the BoardHistory.
    /// </summary>
    public class BoardHistory : IMemento
    {
        /// <summary>
        /// Private field that holds board states.
        /// </summary>
        private IList<IFrame> boardStates;

        /// <summary>
        /// Holds current index.
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// Initializes a new instance of the BoardHistory class.
        /// </summary>
        public BoardHistory()
        {
            this.boardStates = new List<IFrame>();
            this.currentIndex = -1;
        }

        /// <summary>
        /// Saves board state.
        /// </summary>
        /// <param name="board">Board of type IFrame.</param>
        public void SaveBoardState(IFrame board)
        {
            this.boardStates.Insert(++this.currentIndex, board.Clone());
        }

        /// <summary>
        /// Clears the history.
        /// </summary>
        public void ClearHistory()
        {
            this.boardStates.Clear();
            this.currentIndex = -1;
        }

        /// <summary>
        /// Returns last saved board state.
        /// </summary>
        /// <returns>Returns IFrame.</returns>
        public IFrame Undo()
        {
            IFrame board = this.boardStates[this.currentIndex];

            if (this.currentIndex <= 0)
            {
                this.currentIndex = 0;
            }
            else
            {
                this.currentIndex--;
                this.boardStates.Remove(board);
            }          

            return board;
        }
    }
}
