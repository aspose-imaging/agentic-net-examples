// HOW-TO: Draw Polygon on Indexed PSD Canvas Using GraphicsPath in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            int width = 500;
            int height = 500;

            var psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed;
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.FromArgb(255, 255, 0, 0),
                Color.FromArgb(255, 0, 255, 0),
                Color.FromArgb(255, 0, 0, 255)
            });

            using (var image = Image.Create(psdOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var points = new PointF[]
                {
                    new PointF(100, 100),
                    new PointF(400, 100),
                    new PointF(350, 400),
                    new PointF(150, 400)
                };

                var polygon = new PolygonShape(points);
                var figure = new Figure();
                figure.AddShape(polygon);
                var path = new GraphicsPath();
                path.AddFigure(figure);

                var pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

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
 * 1. When you need to generate a PSD file with a limited color palette and overlay a custom polygon shape for a web‑based design preview.
 * 2. When creating automated thumbnails for Photoshop documents that require vector‑based outlines drawn on an indexed image.
 * 3. When building a batch process that adds a border or mask polygon to existing PSD layers while preserving the file’s indexed color mode.
 * 4. When programmatically producing printable mock‑ups where the shape must be defined with precise points using Aspose.Imaging’s GraphicsPath.
 * 5. When integrating a C# service that draws geometric annotations on PSD files before they are saved to a content‑management system.
 */
