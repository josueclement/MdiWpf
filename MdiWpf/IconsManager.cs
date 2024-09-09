using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace MdiWpf;

/// <summary>
/// MDI icons manager
/// </summary>
public static class IconsManager
{
    private static readonly Assembly Assembly = typeof(IconsManager).Assembly;

    /// <summary>
    /// Get icon geometry by its name
    /// </summary>
    /// <param name="name">Icon name</param>
    /// <returns>Icon geometry</returns>
    public static Geometry? GetIconGeometry(string name)
    {
        try
        {
            var stream = Assembly.GetManifestResourceStream($"MdiWpf.svg.{name}.svg");

            if (stream is null)
                return null;

            string content;
            using (stream)
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            
            var xml = new XmlDocument();
            xml.LoadXml(content);
        
            var nsMgr = new XmlNamespaceManager(xml.NameTable);
            nsMgr.AddNamespace("std", "http://www.w3.org/2000/svg");
        
            var node = xml.SelectSingleNode("/std:svg/std:path", nsMgr);
            if (node?.Attributes?["d"] is { } attr)
            {
                var dataStr = attr.Value;
                return Geometry.Parse(dataStr);
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Get icon image source by its name and brush
    /// </summary>
    /// <param name="name">Icon name</param>
    /// <param name="brush">Icon brush</param>
    /// <returns></returns>
    public static DrawingImage? GetIconImageSource(string name, Brush brush)
    {
        var geometry = GetIconGeometry(name);

        if (geometry is null)
            return null;
        
        var drawingImage = new DrawingImage(new GeometryDrawing()
        {
            Geometry = geometry,
            Brush = brush
        });
        drawingImage.Freeze();
        
        return drawingImage;
    }
}