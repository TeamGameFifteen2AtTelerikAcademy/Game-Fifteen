namespace GameFifteen.Logic.Scoreboards.Contracts
{
    using System;

    public interface IScore
    {
        int Moves { get; }

        string PlayerNeme { get; }
    }
}