namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic.Games.Contracts;

    public interface IGameInitializer
    {
        IGame Initialize();
    }
}
