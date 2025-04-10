using Microsoft.Extensions.DependencyInjection;
using System.Windows.Markup;
using System;

namespace MdiWpf;

/// <summary>
/// Provides an icon geometry
/// </summary>
public class IconGeometryExtension : MarkupExtension
{
    /// <summary>
    /// Icon name
    /// </summary>
    public string IconName { get; set; } = string.Empty;

    /// <inheritdoc />
    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        var factory = serviceProvider.GetService<IconsFactory>() ?? new IconsFactory();
        return factory.CreateIconGeometry(IconName);
    }
}