using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MdiWpf;

namespace Tester;

public class MainWindowViewModel : ObservableObject
{
    // TODO: replace with DI
    private static readonly IconsFactory Factory = new();
    
    public MainWindowViewModel()
    {
        Brush = Brushes.Blue;
        Geometry = Factory.CreateIconGeometry("source-repository");
        ChangeIconCommand = new RelayCommand(ChangeIcon);
    }
    
    public Brush? Brush
    {
        get => _brush;
        set => SetProperty(ref _brush, value);
    }
    private Brush? _brush;

    public Geometry? Geometry
    {
        get => _geometry;
        set => SetProperty(ref _geometry, value);
    }
    private Geometry? _geometry;
    
    public RelayCommand ChangeIconCommand { get; }

    private void ChangeIcon()
    {
        Geometry = Factory.CreateIconGeometry("sync-circle");
        Brush = Brushes.Red;
    }
}