﻿namespace GameFifteen.UI.Console.Commands
{
    using System;
    using GameFifteen.Logic.Commands;
    using Logic.Common;

    public class RestartCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Game.Shuffle();
            context.Message  = Constants.WellcomeMessage;
        }
    }
}
