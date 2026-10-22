using System.Collections.ObjectModel;
using System.Windows.Input;
using Axon.Models;

namespace Axon.ViewModels;

/// <summary>
/// ViewModel untuk tampilan koleksi musik (Library View).
/// Pada Fase 1, koleksi kosong dan menampilkan Empty State yang jelas serta informatif.
/// Tidak ada lagu tiruan (fake tracks) yang ditampilkan sebagai lagu riil.
/// </summary>
public class LibraryViewModel : ViewModelBase
{
    private string _searchQuery = string.Empty;

    public LibraryViewModel()
    {
        Tracks = new ObservableCollection<Track>();
        ImportFolderPlaceholderCommand = new RelayCommand(ExecuteImportPlaceholder);
    }

    /// <summary>
    /// Koleksi lagu di library. Saat ini kosong (Fase 1).
    /// </summary>
    public ObservableCollection<Track> Tracks { get; }

    /// <summary>
    /// Menandakan apakah perpustakaan kosong.
    /// </summary>
    public bool IsEmpty => Tracks.Count == 0;

    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    public ICommand ImportFolderPlaceholderCommand { get; }

    private void ExecuteImportPlaceholder()
    {
        // Tombol informatif: Fitur import folder lokal & pembacaan metadata akan diaktifkan pada Fase 2.
    }
}
