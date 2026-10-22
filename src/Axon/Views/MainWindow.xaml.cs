using System.Windows;

namespace Axon.Views;

/// <summary>
/// Code-behind untuk MainWindow.xaml.
/// Sesuai pola MVVM murni, logika navigasi dan status diatur oleh MainViewModel.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
