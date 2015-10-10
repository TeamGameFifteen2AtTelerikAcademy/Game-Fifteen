// <copyright file="UndoCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// UndoCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;

    /// <summary>
    /// UndoCommand class.
    /// </summary>
    public class UndoCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute undo command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.Game.Frame = context.BoardHistory.Undo();
        }
    }
}
