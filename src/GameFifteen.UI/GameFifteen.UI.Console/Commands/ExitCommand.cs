// <copyright file="ExitCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ExitCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using Logic.Commands;

    /// <summary>
    /// ExitCommand class.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute exit command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.IsGameOver = true;
            context.Message = string.Empty;
        }
    }
}
