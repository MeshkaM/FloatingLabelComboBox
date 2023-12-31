using System;

namespace Simplified
{
    /// <summary> RelayCommand implementation for generic parameter methods. </summary>
    /// <typeparam name = "T"> Method parameter type. </typeparam>  
    public class RelayCommand<T> : RelayCommand
    {
        /// <inheritdoc cref="RelayCommand(ExecuteHandler, CanExecuteHandler)"/>
        public RelayCommand(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute)
            : base
            (
                  (execute is null ? default(ExecuteHandler<object>) :
                  p => execute((T)p))
                  ?? throw new ArgumentNullException(nameof(execute)),

                  (canExecute is null ? default(CanExecuteHandler<object>) :
                  p => (p is T t) && canExecute(t))
                  ?? throw new ArgumentNullException(nameof(canExecute))
            )
        { }
        /// <inheritdoc cref="RelayCommand(ExecuteHandler, CanExecuteHandler)"/>
        public RelayCommand(ExecuteHandler<T> execute)
            : base
            (
                  (execute is null ? default(ExecuteHandler<object>) :
                  p => execute((T)p))
                  ?? throw new ArgumentNullException(nameof(execute)),
                  AlwaysCanExecute
            )
        { }
    }
}