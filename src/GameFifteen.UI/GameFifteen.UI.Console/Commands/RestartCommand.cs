// <copyright file="RestartCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// RestartCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;
    using Logic.Common;

    /// <summary>
    /// RestartCommand class.
    /// </summary>
    public class RestartCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute restart command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.Game.Shuffle();
            //context.Message = Constants.WellcomeMessage;
            context.BoardHistory.ClearHistory();
            context.BoardHistory.SaveBoardState(context.Game.Frame);
            context.Moves = 0;
        }
    }
}
