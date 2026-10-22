namespace Axon.Models;

/// <summary>
/// Model data untuk lagu/track musik dalam AXON.
/// Dalam arsitektur MVVM, Model adalah representasi murni dari data tanpa logika UI.
/// </summary>
public class Track
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public string? ArtworkPath { get; set; }
    public int? Year { get; set; }
    public string? Genre { get; set; }

    /// <summary>
    /// Menampilkan durasi dalam format menit:detik (contoh: 03:45).
    /// </summary>
    public string FormattedDuration => Duration.ToString(@"mm\:ss");
}
