using System;
using System.Windows;
using System.Windows.Input;

namespace Simplified
{
    /// <summary> A class that implements <see cref = "ICommand" />. <br/>
    /// Implementation taken from <see href = "https://www.cyberforum.ru/wpf-silverlight/thread2390714-page4.html#post13535649" />
    /// and added a constructor for methods without a parameter.</summary>
    public class RelayCommand : ICommand
    {
        private readonly CanExecuteHandler<object> canExecute;
        private readonly ExecuteHandler<object> execute;
        private readonly EventHandler requerySuggested;

        /// <inheritdoc cref="ICommand.CanExecuteChanged"/>
        public event EventHandler CanExecuteChanged;

        /// <summary> Command constructor. </summary>
        /// <param name = "execute"> Command method to execute. </param>
        /// <param name = "canExecute"> Method that returns the state of the command. </param>
        public RelayCommand(ExecuteHandler<object> execute, CanExecuteHandler<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));

            requerySuggested = (o, e) => Invalidate();
            CommandManager.RequerySuggested += requerySuggested;
            Invalidate = () => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{T}, CanExecuteHandler{T})"/>
        public RelayCommand(ExecuteHandler<object> execute)
           : this(execute, AlwaysCanExecute)
        { }

        public static readonly CanExecuteHandler<object> AlwaysCanExecute = _ => true;

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{T}, CanExecuteHandler{T})"/>
        public RelayCommand(ExecuteHandler execute, CanExecuteHandler canExecute)
                : this
                (
                      (execute is null ? default(ExecuteHandler<object>) : p => execute()) ?? throw new ArgumentNullException(nameof(execute)),
                      (canExecute is null ? default(CanExecuteHandler<object>) : p => canExecute()) ?? throw new ArgumentNullException(nameof(canExecute))
                )
        { }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{T}, CanExecuteHandler{T})"/>
        public RelayCommand(ExecuteHandler execute)
                : this
                (
                      (execute is null ? (ExecuteHandler<object>)null : p => execute()) ?? throw new ArgumentNullException(nameof(execute)),
                      AlwaysCanExecute
                )
        { }

        /// <summary> The method that raises the event <see cref = "CanExecuteChanged" />. </summary>
        public void RaiseCanExecuteChanged()
        {
            if (Application.Current.Dispatcher.CheckAccess())
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            else
                Application.Current.Dispatcher.BeginInvoke(Invalidate);
        }
        private readonly Action Invalidate;

        /// <inheritdoc cref="ICommand.CanExecute(object)"/>
        public bool CanExecute(object parameter) => canExecute(parameter);

        /// <inheritdoc cref="ICommand.Execute(object)"/>
        public void Execute(object parameter) => execute(parameter);
    }
}
