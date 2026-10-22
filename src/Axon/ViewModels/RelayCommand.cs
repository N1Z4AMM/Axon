using System.Windows.Input;

namespace Axon.ViewModels;

/// <summary>
/// Implementasi ICommand standar untuk menghubungkan aksi UI (seperti tombol ditekan)
/// ke method di ViewModel tanpa perlu menulis kode di code-behind (XAML.cs).
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => _execute();

    /// <summary>
    /// Memaksa UI untuk mengevaluasi ulang status CanExecute.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}

/// <summary>
/// Varian generik dari RelayCommand yang menerima parameter dari CommandParameter di XAML.
/// </summary>
public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Predicate<T>? _canExecute;

    public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        if (_canExecute == null) return true;
        if (parameter is T val) return _canExecute(val);
        if (parameter == null && default(T) == null) return _canExecute(default!);
        return false;
    }

    public void Execute(object? parameter)
    {
        if (parameter is T val)
        {
            _execute(val);
        }
        else if (parameter == null && default(T) == null)
        {
            _execute(default!);
        }
    }

    public void RaiseCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
