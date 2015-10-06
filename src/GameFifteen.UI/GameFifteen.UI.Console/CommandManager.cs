namespace GameFifteen.UI.Console
{
    using System;
    using GameFifteen.Logic.Commands;
    using Commands;

    internal class CommandManager : ICommandManager
    {
        public CommandManager()
        {
        }

        public ICommand GetCommand(string command)
        {
            // Enum.IsDefined(typeof(UserCommands), userInput) for parsing numbers 
            UserCommands userCommand = (UserCommands)Enum.Parse(typeof(UserCommands), command);
            switch (userCommand)
            {
                case UserCommands.Restart:
                    return new RestartCommand();
                case UserCommands.Top:
                    return new ShowScoresCommand();
                case UserCommands.Exit:
                    return new ExitCommand();
                case UserCommands.Undo:
                    return new UndoCommand();
<<<<<<< HEAD
                case UserCommands.Move:
=======
                default:
>>>>>>> a784f799e760ea34e43ef0582b8fcf0f58228e63
                    return new MoveCommand();
                default:
                    return new IncorrectCommand();
            }
        }
    }
}