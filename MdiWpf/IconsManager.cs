using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace MdiWpf;

internal static class IconsManager
{
    private static readonly Assembly Assembly = typeof(IconsManager).Assembly;

    internal static Geometry? GetIconGeometry(string iconName)
    {
        try
        {
            var stream = Assembly.GetManifestResourceStream($"MdiWpf.svg.{iconName}.svg");

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

    internal static DrawingImage? GetIconImageSource(string iconName, Brush brush)
    {
        var geometry = GetIconGeometry(iconName);

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