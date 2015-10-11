// <copyright file="IGameInitializer.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IGameInitializer.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic.Games.Contracts;

    /// <summary>
    /// Interface for IGameInitializer.
    /// </summary>
    public interface IGameInitializer
    {
        /// <summary>
        /// The method should returns  IGame.
        /// </summary>
        /// <returns>The IGame.</returns>
        IGame Initialize();
    }
}
