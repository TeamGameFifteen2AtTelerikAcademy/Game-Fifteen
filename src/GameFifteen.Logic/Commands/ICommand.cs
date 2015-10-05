namespace GameFifteen.Logic.Commands
{
    public interface ICommand
    {
        void Execute(ICommandContext ctx);
    }
}
