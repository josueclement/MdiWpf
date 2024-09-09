using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace MdiWpf;

/// <summary>
/// Provides an icon image source based on its name
/// </summary>
public class IconSourceExtension : MarkupExtension
{
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
    {
        return IconsManager.GetIconImageSource(IconName, Brush);
    }
}