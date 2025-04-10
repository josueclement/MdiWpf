using System;
using System.Windows.Markup;

namespace MdiWpf;

/// <summary>
/// Provides an icon geometry
/// </summary>
public class IconGeometryExtension : MarkupExtension
{
    private static readonly IconsFactory Factory = new();
    
    /// <summary>
    /// Icon name
    /// </summary>
    public string IconName { get; set; } = string.Empty;

    /// <inheritdoc />
    public override object? ProvideValue(IServiceProvider serviceProvider)
        => Factory.CreateIconGeometry(IconName);
}