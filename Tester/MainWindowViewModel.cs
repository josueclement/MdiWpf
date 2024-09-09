using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MdiWpf;

namespace Tester;

public class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        Brush = Brushes.Blue;
        Geometry = IconsManager.GetIconGeometry("source-repository");
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
        Geometry = IconsManager.GetIconGeometry("sync-circle");
        Brush = Brushes.Red;
    }
}