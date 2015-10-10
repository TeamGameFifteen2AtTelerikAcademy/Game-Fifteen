namespace GameFifteen.Logic.Commands
{
    /// <summary>
    /// Interface for ICommand
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute command
        /// </summary>
        /// <param name="ctx">ICommandContext</param>
        void Execute(ICommandContext ctx);
    }
}
