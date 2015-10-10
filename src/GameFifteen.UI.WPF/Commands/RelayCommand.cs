// <copyright file="RelayCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// RelayCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// ExecuteDelegate accepts object.
    /// </summary>
    /// <param name="parameter">Delegate's object.</param>
    public delegate void ExecuteDelegate(object parameter);

    /// <summary>
    /// CanExecuteDelegate accepts object.
    /// </summary>
    /// <param name="parameter">Delegate's object.</param>
    /// <returns>True or false.</returns>
    public delegate bool CanExecuteDelegate(object parameter);

    /// <summary>
    /// RelayCommand class inherits .NET ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Holds ExecuteDelegate.
        /// </summary>
        private ExecuteDelegate execute;

        /// <summary>
        /// Holds CanExecuteDelegate.
        /// </summary>
        private CanExecuteDelegate canExecute;

        /// <summary>
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <param name="execute">The Execute Delegate.</param>
        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class overload.
        /// </summary>
        /// <param name="execute">The Execute Delegate.</param>
        /// <param name="canExecute">The Can Execute Delegate.</param>
        public RelayCommand(ExecuteDelegate execute, CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Holds EventHandler for CanExecuteDelegate is  Changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// The method returns if the command can be executed.
        /// </summary>
        /// <param name="parameter">Object parameter to check.</param>
        /// <returns>True or false.</returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute(parameter);
        }

        /// <summary>
        /// The methods executes the parameter.
        /// </summary>
        /// <param name="parameter">The parameter to execute.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
