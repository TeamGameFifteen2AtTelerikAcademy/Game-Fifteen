// <copyright file="ICommandManager.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ICommandManager.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Commands
{
    using System;
  
    /// <summary>
    /// Interface for ICommandManager.
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// The method returns ICommand by given string name.
        /// </summary>
        /// <param name="command">The name of the command in String format.</param>
        /// <returns>ICommand command.</returns>
        ICommand GetCommand(string command);

        /// <summary>
        /// The method returns ICommand by given Enum.
        /// </summary>
        /// <param name="command">The name of the command of type Enum.</param>
        /// <returns>ICommand command.</returns>
        ICommand GetCommand(Enum command);
    }
}
