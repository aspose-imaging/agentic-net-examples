// HOW-TO: How To Set Brush Opacity When Filling Shapes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (var image = Aspose.Imaging.Image.Create(options, 300, 200))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();

                var rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(50, 50, 200, 100));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (var brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    brush.Color = Aspose.Imaging.Color.FromArgb(128, Aspose.Imaging.Color.Blue);
                    graphics.FillPath(brush, path);
                }

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a semi‑transparent rectangle overlay on a PNG image for highlighting a region in a C# reporting tool.
 * 2. When generating UI assets that require a partially see‑through button background using Aspose.Imaging’s SolidBrush with a custom Alpha value.
 * 3. When adding a watermark with adjustable opacity to images before saving them as PNG files in an automated batch process.
 * 4. When designing custom graphics for a game UI where shapes must be filled with colors that blend with the background via the FillPath method.
 * 5. When producing visual documentation that shows overlapping shapes with varying transparency to illustrate layer effects.
 */
