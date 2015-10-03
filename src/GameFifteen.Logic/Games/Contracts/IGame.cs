namespace GameFifteen.Logic.Games.Contracts
{
    public interface IGame
    {
        bool IsSolved { get; }

        void Move(string tileLabel);

        void Shuffle();
    }
}
