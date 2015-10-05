﻿using GameFifteen.Logic.Frames.Contracts;
using GameFifteen.Logic.Scoreboards;

namespace GameFifteen.Logic.Games.Contracts
{
    public interface IGame
    {
        bool IsSolved { get; }

        IFrame Board { get; }

        bool Move(string tileLabel);

        void Shuffle();

        //IScoreboard Scoreboard { get; set; }
    }
}
