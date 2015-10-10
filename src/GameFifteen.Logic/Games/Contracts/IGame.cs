namespace GameFifteen.Logic.Games.Contracts
{
    using GameFifteen.Logic.Frames.Contracts;

    public interface IGame
    {
        bool IsSolved { get; }

        IFrame Frame { get; set; }

        IFrame FramePrototype { get; }

        bool Move(string tileLabel);

        void Shuffle();
    }
}
