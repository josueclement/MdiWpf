using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace MdiWpf;

/// <summary>
/// MDI icons manager
/// </summary>
public class IconsFactory
{
    private static readonly Assembly Assembly = typeof(IconsFactory).Assembly;

    /// <summary>
    /// Create an icon geometry
    /// </summary>
    /// <param name="iconName">Icon name</param>
    /// <returns>Icon geometry</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public Geometry CreateIconGeometry(string iconName)
    {
        using var stream = Assembly.GetManifestResourceStream($"MdiWpf.svg.{iconName}.svg")
                           ?? throw new InvalidOperationException($"Icon '{iconName}' not found");
        using var sr = new StreamReader(stream);
        var content = sr.ReadToEnd();

        var xml = new XmlDocument();
        xml.LoadXml(content);
        var xnm = new XmlNamespaceManager(xml.NameTable);
        xnm.AddNamespace("std", "http://www.w3.org/2000/svg");
        var node = xml.SelectSingleNode("/std:svg/std:path", xnm);

        if (node?.Attributes?["d"]?.Value is { } val)
            return Geometry.Parse(val);

        throw new InvalidOperationException($"Cannot read icon '{iconName}'");
    }

    /// <summary>
    /// Create an ImageSource
    /// </summary>
    /// <param name="iconName">Icon name</param>
    /// <param name="brush">Icon brush</param>
    /// <returns>DrawingImage</returns>
    public DrawingImage CreateDrawingImage(string iconName, Brush brush)
    {
        var geometry = CreateIconGeometry(iconName);

        var drawingImage = new DrawingImage(new GeometryDrawing
        {
            Geometry = geometry,
            Brush = brush
        });
        drawingImage.Freeze();
        
        return drawingImage;
    }
}