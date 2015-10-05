﻿using GameFifteen.Logic.Frames.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen.Logic.Memento
{
    public class BoardHistory : IMemento
    {
        private IList<IFrame> boardStates;
        private int currentIndex;

        public BoardHistory()
        {
            this.boardStates = new List<IFrame>();
            this.currentIndex = -1;
        }

        public void SaveBoardState(IFrame board)
        {
            this.boardStates.Insert(++this.currentIndex, board.Clone());
            //this.currentIndex++;
        }

        public void ClearHistory()
        {
            this.boardStates.Clear();
            this.currentIndex = -1;
        }

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