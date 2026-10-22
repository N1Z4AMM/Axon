using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Axon.ViewModels;

/// <summary>
/// Kelas dasar untuk semua ViewModel di AXON.
/// Mengimplementasikan INotifyPropertyChanged agar View (XAML) dapat
/// mengetahui secara otomatis saat ada nilai properti yang berubah (Data Binding).
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Memanggil event PropertyChanged untuk memberitahu XAML bahwa properti telah berubah.
    /// CallerMemberName otomatis mengisi nama properti pemanggil tanpa perlu hardcode string.
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Helper untuk memperbarui nilai backing field dan memicu PropertyChanged jika nilainya berbeda.
    /// Mengembalikan true jika nilai berubah, false jika nilainya sama.
    /// </summary>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
