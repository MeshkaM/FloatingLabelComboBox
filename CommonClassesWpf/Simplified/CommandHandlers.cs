namespace Simplified
{
    #region Delegates for WPF Command Methods
    public delegate void ExecuteHandler();
    public delegate bool CanExecuteHandler();

    public delegate void ExecuteHandler<T>(T parameter);
    public delegate bool CanExecuteHandler<T>(T parameter);
    #endregion
}
