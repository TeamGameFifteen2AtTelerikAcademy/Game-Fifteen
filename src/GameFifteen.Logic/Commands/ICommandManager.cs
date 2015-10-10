namespace GameFifteen.Logic.Commands
{
    using System;
  
    /// <summary>
    /// Interface for ICommandMenager;
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// The method returns ICommand by given strin name
        /// </summary>
        /// <param name="command">the name of the command in String format</param>
        /// <returns>ICommand</returns>
        ICommand GetCommand(string command);

        /// <summary>
        /// The method returns ICommand by given Enum
        /// </summary>
        /// <param name="command">the name of the command ot type Enum</param>
        /// <returns>ICommand</returns>
        ICommand GetCommand(Enum command);
    }
}
