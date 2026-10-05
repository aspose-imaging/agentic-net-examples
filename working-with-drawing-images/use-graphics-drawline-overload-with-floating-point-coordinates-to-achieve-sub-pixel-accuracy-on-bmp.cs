// HOW-TO: Draw Subpixel Accurate Line on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 32,
                Source = new FileCreateSource(outputPath, false)
            };

            using (var image = Image.Create(bmpOptions, 200, 200))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);

                var pen = new Pen(Color.Blue, 1);
                // Sub‑pixel line using floating‑point coordinates
                graphics.DrawLine(pen, 10.5f, 10.5f, 190.3f, 190.7f);

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
 * 1. When you need to render crisp diagonal lines on a 32‑bit BMP for a UI overlay where sub‑pixel precision improves visual quality.
 * 2. When generating technical diagrams programmatically and require exact line placement on bitmap files without rasterization artifacts.
 * 3. When creating high‑resolution map tiles in BMP format and must draw routes with floating‑point coordinates for smooth curves.
 * 4. When building a custom charting component that draws trend lines on a BMP background and needs sub‑pixel accuracy for precise data representation.
 * 5. When exporting scanned document annotations to BMP and want the annotation lines to align accurately with fractional pixel positions.
 */
