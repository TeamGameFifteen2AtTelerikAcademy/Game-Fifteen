// <copyright file="ISwitchable.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ISwitchable.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Contracts
{
    /// <summary>
    /// Interface for ISwitchable.
    /// </summary>
    public interface ISwitchable
    {
        /// <summary>
        /// The method should utilize the state of the object to bi switched.
        /// </summary>
        /// <param name="state">Object's state.</param>
        void UtilizeState(object state);
    }
}
