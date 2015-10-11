// <copyright file="MasterModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// MasterModel class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Models
{
    /// <summary>
    /// MasterModel class - represents the model of the master.
    /// </summary>
    public class MasterModel
    {
        /// <summary>
        /// Gets or sets master's Name.
        /// </summary>
        /// <value>Name of the master as string.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets master's "GH" URL link.
        /// </summary>
        /// <value>GH URL link of the master as string.</value>
        public string GithbUrl { get; set; }

        /// <summary>
        /// Gets or sets master's "GH" nickname.
        /// </summary>
        /// <value>GH nickname of the master as string.</value>
        public string GitgunNick { get; set; }

        /// <summary>
        /// Gets or sets master's "TA" nickname.
        /// </summary>
        /// <value>TA nickname of the master as string.</value>
        public string TaNick { get; set; }
    }
}
