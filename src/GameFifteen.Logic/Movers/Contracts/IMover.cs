namespace GameFifteen.Logic.Movers.Contracts
{
    using GameFifteen.Logic.Frames.Contracts;

    public interface IMover
    {
        bool Move(string tileLabel, IFrame frame);

        void Shuffle(IFrame frame);
    }
}
