// <copyright file="IncorrectCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// IncorrectCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;
    using Logic.Common;

    /// <summary>
    /// IncorrectCommand class.
    /// </summary>
    public class IncorrectCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute incorrect command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.Message = Constants.InvalidCommandMessage;
        }
    }
}
