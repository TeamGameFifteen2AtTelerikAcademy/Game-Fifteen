// <copyright file="ICommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ICommand.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Commands
{
    /// <summary>
    /// Interface for ICommand.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute command.
        /// </summary>
        /// <param name="ctx">Context of type ICommandContext.</param>
        void Execute(ICommandContext ctx);
    }
}
