// <copyright file="CommandManager.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// CommandManager class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.CommandFactory
{
    using System;
    using System.Collections.Generic;
    using GameFifteen.Logic.Commands;
    using GameFifteen.UI.Console.Commands;
    using GameFifteen.UI.Console.Helpers;

    /// <summary>
    /// CommandManager class.
    /// </summary>
    internal class CommandManager : ICommandManager
    {
        /// <summary>
        /// Holds the already created commands. Works like cache provider.
        /// </summary>
        private readonly Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();

        /// <summary>
        /// The method returns ICommand by given string name.
        /// </summary>
        /// <param name="command">The name of the command in String format.</param>
        /// <returns>ICommand command.</returns>
        public ICommand GetCommand(string command)
        {
            if (this.commandDictionary.ContainsKey(command))
            {
                return this.commandDictionary[command];
            }

            UserCommands userCommand;
            if (Enum.IsDefined(typeof(UserCommands), command) &&
                Enum.TryParse<UserCommands>(command, out userCommand))
            {
                ICommand currentCommand = this.GetCommand(userCommand);
                this.commandDictionary.Add(command, currentCommand);
                return currentCommand;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// The method returns ICommand by given enumeration.
        /// </summary>
        /// <param name="command">The name of the command of type enumeration.</param>
        /// <returns>ICommand command.</returns>
        public ICommand GetCommand(Enum command)
        {
            switch ((UserCommands)command)
            {
                case UserCommands.Restart:
                    return new RestartCommand();
                case UserCommands.Top:
                    return new ShowScoresCommand();
                case UserCommands.Exit:
                    return new ExitCommand();
                case UserCommands.Undo:
                    return new UndoCommand();
                case UserCommands.Move:
                    return new MoveCommand();
                default:
                    return new IncorrectCommand();
            }
        }
    }
}