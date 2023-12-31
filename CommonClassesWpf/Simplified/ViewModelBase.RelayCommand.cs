using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Simplified
{
    public abstract partial class ViewModelBase
    {
        private readonly Dictionary<string, RelayCommand> commands = new Dictionary<string, RelayCommand>();

        /// <summary>Command factory constructor.</summary>
        /// <typeparam name="T">Command parameter type.</typeparam>
        /// <param name="execute">The command method to be executed.</param>
        /// <param name="canExecute">Method that returns the command state.</param>
        /// <param name="converter">Delegate of the method that converts <see cref="object"/> to type <typeparamref name="T"/>.</param>
        /// <param name="commandName">The name of the command is usually the name of the property.</param>
        /// <returns>Returns an instance of <see cref="RelayCommand"/>.
        /// All commands are contained in a common dictionary under the key <paramref name="commandName"/>.
        /// If the command is not in the dictionary, then it is created and written to the dictionary.
        /// Created commands are subscribed to <see cref="CommandManager.RequerySuggested"/>.</returns>
        /// <exception cref="ArgumentException">If one of the parameters <see langword="null"/>
        /// or if <see cref="string.IsNullOrWhiteSpace(string?)">string.IsNullOrWhiteSpace(<paramref name="commandName"/>)</see>.</exception>
        protected RelayCommand GetCommand<T>(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand<T>(execute, canExecute);
                commands.Add(commandName, command);
            }
            return command;
        }

        ///<inheritdoc cref="GetCommand{T}(ExecuteHandler{T}, CanExecuteHandler{T}, ConverterFromObjectHandler{T}, string?)"/>
        protected RelayCommand GetCommand<T>(ExecuteHandler<T> execute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand<T>(execute);
                commands.Add(commandName, command);
            }
            return command;
        }


        ///<inheritdoc cref="GetCommand{T}(ExecuteHandler{T}, CanExecuteHandler{T}, ConverterFromObjectHandler{T}, string?)"/>
        protected RelayCommand GetCommand(ExecuteHandler execute, CanExecuteHandler canExecute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand(execute, canExecute);
                commands.Add(commandName, command);
            }
            return command;
        }

        ///<inheritdoc cref="GetCommand{T}(ExecuteHandler{T}, CanExecuteHandler{T}, ConverterFromObjectHandler{T}, string?)"/>
        protected RelayCommand GetCommand(ExecuteHandler execute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand(execute);
                commands.Add(commandName, command);
            }
            return command;
        }

        ///<inheritdoc cref="GetCommand{T}(ExecuteHandler{T}, CanExecuteHandler{T}, ConverterFromObjectHandler{T}, string?)"/>
        protected RelayCommand GetCommand(ExecuteHandler<object> execute, CanExecuteHandler<object> canExecute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand(execute, canExecute);
                commands.Add(commandName, command);
            }
            return command;
        }

        ///<inheritdoc cref="GetCommand{T}(ExecuteHandler{T}, CanExecuteHandler{T}, ConverterFromObjectHandler{T}, string?)"/>
        protected RelayCommand GetCommand(ExecuteHandler<object> execute, [CallerMemberName] string commandName = null)
        {
            if (!commands.TryGetValue(commandName, out var command))
            {
                command = new RelayCommand(execute);
                commands.Add(commandName, command);
            }
            return command;
        }

        /// <summary>Method of obtaining an already created command.</summary>
        /// <param name="commandName">Command name; if not specified, the name of the calling method is used.</param>
        /// <returns>Returns an instance of <see cref="RelayCommand"/>.
        /// All commands are contained in a common dictionary under the key <paramref name="commandName"/>.
        /// If the command is not in the dictionary, an exception will be thrown.</returns>
        protected RelayCommand GetCommand([CallerMemberName] string commandName = null)
        {
            if (string.IsNullOrWhiteSpace(commandName))
                throw commandNameException;

            if (commands.TryGetValue(commandName, out RelayCommand command))
                return command;
            throw notCommandException;
        }

        /// <summary>Removes a command.</summary>
        /// <param name="commandName">Command name.</param>
        /// <returns><see langword="true"/> if the command was removed.</returns>
        protected bool RemoveCommnad(string commandName) => commands.Remove(commandName);


        protected static readonly ArgumentException executeException = new ArgumentException("null is not allowed", "execute");
        protected static readonly ArgumentException canExecuteException = new ArgumentException("null is not allowed", "canExecute");
        protected static readonly ArgumentException converterException = new ArgumentException("null is not allowed", "converter");
        protected static readonly ArgumentException commandNameException = new ArgumentException("null, Empty and only Spaces is not allowed", "commandName");
        protected static readonly ArgumentException notCommandException = new ArgumentException("Command not found", "commandName");
    }
}
