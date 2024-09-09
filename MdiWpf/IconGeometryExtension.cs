using System;
using System.Windows.Markup;

namespace MdiWpf;

/// <summary>
/// Provides an icon geometry based on its name
/// </summary>
public class IconGeometryExtension : MarkupExtension
{
    /// <summary>
    /// Icon name
    /// </summary>
    public string IconName { get; set; } = string.Empty;
    
    /// <inheritdoc />
    public override object? ProvideValue(IServiceProvider serviceProvider)
        => IconsManager.GetIconGeometry(IconName);
}