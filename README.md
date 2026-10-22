# AXON — Premium Windows Desktop Music Player

AXON adalah aplikasi desktop pemutar musik lokal berarsitektur C#, WPF, MVVM, SQLite, dan NAudio dengan estetika gelap titanium/charcoal/graphite yang elegan dan performa ringan yang dioptimasi untuk laptop berspesifikasi harian.

## Status: Fase 1 (Application Foundation) — Selesai

- [x] Struktur proyek rapi (`Axon.sln` + `src/Axon`)
- [x] Pondasi MVVM (`ViewModelBase`, `RelayCommand`, `DataTemplate` view routing)
- [x] Shell UI lengkap:
  - Navigasi sidebar dengan logo audio waveform
  - Tampilan perpustakaan (`LibraryView`) dengan **Empty State** yang jujur dan informatif
  - Bar kontrol bawah (`PlaybackBarView`) dengan status tombol disabled sebelum lagu dimuat
  - Halaman pengaturan (`SettingsView`) dengan pemilih warna aksen realtime (Titanium Amber, Emerald Sage, Electric Violet, Warm Coral, Glacier Cyan)
- [x] Desain responsif mendukung resolusi laptop 1366×768 (min. 1024×640)
- [x] Target hardware: Intel Core i5-4200U, 8GB RAM, Windows 10, penyimpanan HDD

## Cara Menjalankan

```powershell
# Jalankan via .NET CLI
dotnet run --project src/Axon/Axon.csproj
```
