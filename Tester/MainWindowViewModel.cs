using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MdiWpf;

namespace Tester;

public class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel(IconsFactory iconsFactory)
    {
        Geometries.Add(new KeyValuePair<string, Geometry>("content-save", iconsFactory.CreateIconGeometry("content-save")));
        Geometries.Add(new KeyValuePair<string, Geometry>("arrow-right-bold-box", iconsFactory.CreateIconGeometry("arrow-right-bold-box")));
        Geometries.Add(new KeyValuePair<string, Geometry>("folder-lock-outline", iconsFactory.CreateIconGeometry("folder-lock-outline")));
        Geometries.Add(new KeyValuePair<string, Geometry>("alert", iconsFactory.CreateIconGeometry("alert")));
        SelectedGeometry = Geometries.FirstOrDefault();
        
        Brushes.Add(new KeyValuePair<string, Brush>("Black", System.Windows.Media.Brushes.Black));
        Brushes.Add(new KeyValuePair<string, Brush>("Red", System.Windows.Media.Brushes.Red));
        Brushes.Add(new KeyValuePair<string, Brush>("Green", System.Windows.Media.Brushes.Green));
        Brushes.Add(new KeyValuePair<string, Brush>("Blue", System.Windows.Media.Brushes.Blue));
        SelectedBrush = Brushes.FirstOrDefault();
    }
    
    public ObservableCollection<KeyValuePair<string, Geometry>> Geometries { get; } = [];
    public ObservableCollection<KeyValuePair<string, Brush>> Brushes { get; } = [];
    
    private KeyValuePair<string, Geometry>? _selectedGeometry;
    public KeyValuePair<string, Geometry>? SelectedGeometry
    {
        get => _selectedGeometry;
        set => SetProperty(ref _selectedGeometry, value);
    }
    
    private KeyValuePair<string, Brush>? _selectedBrush;
    public KeyValuePair<string, Brush>? SelectedBrush
    {
        get => _selectedBrush;
        set => SetProperty(ref _selectedBrush, value);
    }
}