using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MdiWpf.Controls;

/// <summary>
/// Vector icon control
/// </summary>
public class VectorIcon : Control
{
    static VectorIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(VectorIcon),
            new FrameworkPropertyMetadata(typeof(VectorIcon)));
    }
    
    #region Geometry

    /// <summary>
    /// Geometry
    /// </summary>
    [Bindable(true)]
    public Geometry Geometry
    {
        get => (Geometry)GetValue(GeometryProperty);
        set => SetValue(GeometryProperty, value);
    }

    /// <summary>
    /// Geometry property
    /// </summary>
    public static readonly DependencyProperty GeometryProperty =
        DependencyProperty.Register(name: nameof(Geometry),
                                    propertyType: typeof(Geometry),
                                    ownerType: typeof(VectorIcon),
                                    typeMetadata: new PropertyMetadata(null, OnGeometryPropertyChanged));

    /// <summary>
    /// Called when <see cref="GeometryProperty"/> has changed
    /// </summary>
    /// <param name="d">Caller</param>
    /// <param name="e">Event</param>
    private static void OnGeometryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((VectorIcon)d).OnGeometryChanged(e);

    /// <summary>
    /// Called when <see cref="Geometry"/> has changed
    /// </summary>
    /// <param name="e">Event</param>
    protected virtual void OnGeometryChanged(DependencyPropertyChangedEventArgs e) { }

    #endregion

    #region Brush

    /// <summary>
    /// Brush
    /// </summary>
    [Bindable(true)]
    public Brush Brush
    {
        get => (Brush)GetValue(BrushProperty);
        set => SetValue(BrushProperty, value);
    }

    /// <summary>
    /// Brush property
    /// </summary>
    public static readonly DependencyProperty BrushProperty =
        DependencyProperty.Register(name: nameof(Brush),
                                    propertyType: typeof(Brush),
                                    ownerType: typeof(VectorIcon),
                                    typeMetadata: new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnBrushPropertyChanged));

    /// <summary>
    /// Called when <see cref="BrushProperty"/> has changed
    /// </summary>
    /// <param name="d">Caller</param>
    /// <param name="e">Event</param>
    private static void OnBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((VectorIcon)d).OnBrushChanged(e);

    /// <summary>
    /// Called when <see cref="Brush"/> has changed
    /// </summary>
    /// <param name="e">Event</param>
    protected virtual void OnBrushChanged(DependencyPropertyChangedEventArgs e) { }

    #endregion
}