// <copyright file="EngineTemplate.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// EngineTemplate abstract class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Engine
{
    /// <summary>
    /// EngineTemplate abstract class.
    /// </summary>
    internal abstract class EngineTemplate
    {
        /// <summary>
        /// The method sets game methods execution sequence.
        /// </summary>
        public void Run()
        {
            this.Welcome();
            this.Play();
            this.Goodbye();
        }

        /// <summary>
        /// The method should handle welcome part.
        /// </summary>
        protected abstract void Welcome();

        /// <summary>
        /// The method should handle play part.
        /// </summary>
        protected abstract void Play();

        /// <summary>
        /// The method should handle end part.
        /// </summary>
        protected abstract void Goodbye();
    }
}