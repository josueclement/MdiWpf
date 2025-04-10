using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace MdiWpf;

/// <summary>
/// Provides an icon image source
/// </summary>
public class IconSourceExtension : MarkupExtension
{
    private static readonly IconsFactory Factory = new();
    
    /// <summary>
    /// Icon brush
    /// </summary>
    public Brush Brush { get; set; } = Brushes.Black;
    
    /// <summary>
    /// Icon name
    /// </summary>
    public string IconName { get; set; } = string.Empty;

    /// <inheritdoc />
    public override object? ProvideValue(IServiceProvider serviceProvider)
        => Factory.CreateDrawingImage(IconName, Brush);
}