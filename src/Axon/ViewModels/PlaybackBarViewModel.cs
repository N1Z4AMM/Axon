using System.Windows.Input;
using Axon.Models;

namespace Axon.ViewModels;

/// <summary>
/// ViewModel untuk panel pemutar musik di bagian bawah (Bottom Playback Bar).
/// Mengelola status pemutaran saat ini (lagu aktif, posisi waktu, volume, play/pause).
/// Pada Fase 1, kontrol pemutaran dinonaktifkan (disabled) sampai ada track riil yang dimuat.
/// </summary>
public class PlaybackBarViewModel : ViewModelBase
{
    private Track? _currentTrack;
    private bool _isPlaying;
    private double _volume = 70.0; // 0 - 100
    private TimeSpan _currentPosition = TimeSpan.Zero;
    private TimeSpan _totalDuration = TimeSpan.Zero;
    private bool _isMuted;
    private double _preMuteVolume = 70.0;

    public PlaybackBarViewModel()
    {
        // Perintah pemutaran: tombol dinonaktifkan di Fase 1 karena CanPlay bernilai false.
        PlayPauseCommand = new RelayCommand(ExecutePlayPause, () => CanPlay);
        PreviousCommand = new RelayCommand(ExecutePrevious, () => CanPlay);
        NextCommand = new RelayCommand(ExecuteNext, () => CanPlay);
        SeekCommand = new RelayCommand<double>(ExecuteSeek, _ => CanPlay);
        ToggleMuteCommand = new RelayCommand(ExecuteToggleMute);
    }

    public ICommand PlayPauseCommand { get; }
    public ICommand PreviousCommand { get; }
    public ICommand NextCommand { get; }
    public ICommand SeekCommand { get; }
    public ICommand ToggleMuteCommand { get; }

    /// <summary>
    /// Track yang sedang aktif. Null jika belum ada file musik yang dipilih.
    /// </summary>
    public Track? CurrentTrack
    {
        get => _currentTrack;
        set
        {
            if (SetProperty(ref _currentTrack, value))
            {
                OnPropertyChanged(nameof(HasTrack));
                OnPropertyChanged(nameof(CanPlay));
                OnPropertyChanged(nameof(DisplayTitle));
                OnPropertyChanged(nameof(DisplayArtist));
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }

    public bool HasTrack => CurrentTrack != null;

    /// <summary>
    /// Kontrol pemutaran hanya dapat aktif jika ada track audio yang valid.
    /// </summary>
    public bool CanPlay => HasTrack;

    public bool IsPlaying
    {
        get => _isPlaying;
        set => SetProperty(ref _isPlaying, value);
    }

    public double Volume
    {
        get => _volume;
        set
        {
            if (SetProperty(ref _volume, Math.Clamp(value, 0.0, 100.0)))
            {
                if (_volume > 0 && _isMuted)
                {
                    _isMuted = false;
                    OnPropertyChanged(nameof(IsMuted));
                }
            }
        }
    }

    public bool IsMuted
    {
        get => _isMuted;
        set => SetProperty(ref _isMuted, value);
    }

    public TimeSpan CurrentPosition
    {
        get => _currentPosition;
        set
        {
            if (SetProperty(ref _currentPosition, value))
            {
                OnPropertyChanged(nameof(FormattedPosition));
            }
        }
    }

    public TimeSpan TotalDuration
    {
        get => _totalDuration;
        set
        {
            if (SetProperty(ref _totalDuration, value))
            {
                OnPropertyChanged(nameof(FormattedDuration));
            }
        }
    }

    public string DisplayTitle => CurrentTrack?.Title ?? "No track loaded";

    public string DisplayArtist => CurrentTrack != null
        ? $"{CurrentTrack.Artist} • {CurrentTrack.Album}"
        : "Select a track to start playback";

    public string FormattedPosition => CurrentPosition.ToString(@"mm\:ss");

    public string FormattedDuration => TotalDuration.ToString(@"mm\:ss");

    private void ExecutePlayPause()
    {
        // Diimplementasikan pada Fase 3 (Integrasi NAudio)
    }

    private void ExecutePrevious()
    {
        // Diimplementasikan pada Fase 3
    }

    private void ExecuteNext()
    {
        // Diimplementasikan pada Fase 3
    }

    private void ExecuteSeek(double position)
    {
        // Diimplementasikan pada Fase 3
    }

    private void ExecuteToggleMute()
    {
        if (IsMuted)
        {
            Volume = _preMuteVolume > 0 ? _preMuteVolume : 50;
            IsMuted = false;
        }
        else
        {
            _preMuteVolume = Volume;
            Volume = 0;
            IsMuted = true;
        }
    }
}
