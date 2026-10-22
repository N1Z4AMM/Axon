using System.Windows.Input;

namespace Axon.ViewModels;

/// <summary>
/// ViewModel utama yang mengatur navigasi antar halaman (Library, Settings)
/// dan menghubungkan komponen shell aplikasi termasuk Bottom Playback Bar.
/// </summary>
public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;
    private readonly LibraryViewModel _libraryViewModel;
    private readonly SettingsViewModel _settingsViewModel;

    public MainViewModel()
    {
        _libraryViewModel = new LibraryViewModel();
        _settingsViewModel = new SettingsViewModel();
        PlaybackBar = new PlaybackBarViewModel();

        // Tampilan awal adalah Library View
        _currentViewModel = _libraryViewModel;

        NavigateToLibraryCommand = new RelayCommand(() => CurrentViewModel = _libraryViewModel);
        NavigateToSettingsCommand = new RelayCommand(() => CurrentViewModel = _settingsViewModel);
    }

    /// <summary>
    /// ViewModel halaman yang sedang ditampilkan di area konten utama.
    /// Diikat (binding) ke ContentControl di MainWindow.xaml.
    /// </summary>
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            if (SetProperty(ref _currentViewModel, value))
            {
                OnPropertyChanged(nameof(IsLibraryActive));
                OnPropertyChanged(nameof(IsSettingsActive));
            }
        }
    }

    public PlaybackBarViewModel PlaybackBar { get; }

    public bool IsLibraryActive => CurrentViewModel is LibraryViewModel;
    public bool IsSettingsActive => CurrentViewModel is SettingsViewModel;

    public ICommand NavigateToLibraryCommand { get; }
    public ICommand NavigateToSettingsCommand { get; }
}
