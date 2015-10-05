﻿using System;
using GameFifteen.Logic.Commands;
using GameFifteen.Logic.Frames.Contracts;
using GameFifteen.Logic.Games.Contracts;
using GameFifteen.Logic.Scoreboards.Contracts;

namespace GameFifteen.UI.Console
{
    public class CommandContext : ICommandContext
    {
        public CommandContext(IGame game, IScoreboard scoreboard)
        {
            this.Game = game;
            this.ScoreboardInfo = scoreboard;
        }

        public IScoreboard ScoreboardInfo { get; set; }

        public IGame Game { get; set; }        

        public string Message { get; set; }

        public string SelectedTileLabel { get; set; }       
    }
}
