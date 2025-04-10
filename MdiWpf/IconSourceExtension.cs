using Microsoft.Extensions.DependencyInjection;
using System.Windows.Markup;
using System.Windows.Media;
using System;

namespace MdiWpf;

/// <summary>
/// Provides an icon image source
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
        var factory = serviceProvider.GetService<IconsFactory>() ?? new IconsFactory();
        return factory.CreateDrawingImage(IconName, Brush);
    }
}