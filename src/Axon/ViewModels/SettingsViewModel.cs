using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Axon.ViewModels;

/// <summary>
/// Opsi warna aksen yang dapat dipilih oleh pengguna.
/// </summary>
public record AccentOption(string Name, Color Color, Brush Brush);

/// <summary>
/// ViewModel untuk tampilan pengaturan (Settings View).
/// Menyediakan pergantian warna aksen secara dinamis serta informasi aplikasi AXON.
/// </summary>
public class SettingsViewModel : ViewModelBase
{
    private AccentOption _selectedAccent;

    public SettingsViewModel()
    {
        AccentOptions = new List<AccentOption>
        {
            new("Titanium Amber", Color.FromRgb(0xE5, 0xA9, 0x3C), new SolidColorBrush(Color.FromRgb(0xE5, 0xA9, 0x3C))),
            new("Emerald Sage", Color.FromRgb(0x10, 0xB9, 0x81), new SolidColorBrush(Color.FromRgb(0x10, 0xB9, 0x81))),
            new("Electric Violet", Color.FromRgb(0x8B, 0x5C, 0xF6), new SolidColorBrush(Color.FromRgb(0x8B, 0x5C, 0xF6))),
            new("Warm Coral", Color.FromRgb(0xF4, 0x3F, 0x5E), new SolidColorBrush(Color.FromRgb(0xF4, 0x3F, 0x5E))),
            new("Glacier Cyan", Color.FromRgb(0x06, 0xB6, 0xD4), new SolidColorBrush(Color.FromRgb(0x06, 0xB6, 0xD4)))
        };

        _selectedAccent = AccentOptions[0];
        ApplyAccentCommand = new RelayCommand<AccentOption>(accent =>
        {
            if (accent != null)
            {
                SelectedAccent = accent;
            }
        });
    }

    public List<AccentOption> AccentOptions { get; }

    public ICommand ApplyAccentCommand { get; }

    public AccentOption SelectedAccent
    {
        get => _selectedAccent;
        set
        {
            if (SetProperty(ref _selectedAccent, value))
            {
                ApplyAccentColor(value.Color);
            }
        }
    }

    public string AppVersion => "0.1.0-alpha (Phase 1 Foundation)";

    public string TargetPlatform => ".NET 8.0 Windows Desktop (WPF)";

    /// <summary>
    /// Mengganti warna aksen pada resource kamus dinamis aplikasi secara realtime.
    /// </summary>
    private static void ApplyAccentColor(Color color)
    {
        if (Application.Current != null)
        {
            Application.Current.Resources["AccentColor"] = color;
            Application.Current.Resources["AccentBrush"] = new SolidColorBrush(color);
            Application.Current.Resources["AccentBrushHover"] = new SolidColorBrush(Color.FromArgb(200, color.R, color.G, color.B));
            Application.Current.Resources["AccentBrushSubtle"] = new SolidColorBrush(Color.FromArgb(40, color.R, color.G, color.B));
        }
    }
}
