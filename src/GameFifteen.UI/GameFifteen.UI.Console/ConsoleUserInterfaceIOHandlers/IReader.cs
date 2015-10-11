// <copyright file="IReader.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IReader.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console
{
    /// <summary>
    /// Interface for IReader.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// The method should read a line.
        /// </summary>
        /// <returns>Read line as string.</returns>
        string ReadLine();

        /// <summary>
        /// The method should parse the input as array of strings.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The array of input strings.</returns>
        string[] ParseInput(string input);
    }
}