// <copyright file="MoveCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// MoveCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using Logic.Commands;
    using Logic.Common;

    /// <summary>
    /// MoveCommand class.
    /// </summary>
    public class MoveCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute move command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.BoardHistory.SaveBoardState(context.Game.Frame);
            bool isSuccessfulMove = context.Game.Move(context.SelectedTileLabel);
            if (isSuccessfulMove)
            {
                context.Moves += 1;
                context.Message = string.Empty;
            }
            else
            {
                context.Message = Constants.InvalidMoveMessage;
            }
        }
    }
}
