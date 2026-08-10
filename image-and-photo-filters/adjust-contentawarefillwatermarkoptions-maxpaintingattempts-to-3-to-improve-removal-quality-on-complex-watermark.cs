// HOW-TO: Remove Complex Watermark from PNG Using ContentAwareFill with Limited Painting Attempts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    result.Save(outputPath);
                }
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
 * 1. When you need to automatically erase an elliptical watermark from a PNG image while preserving surrounding pixels.
 * 2. When processing a batch of product photos that contain semi‑transparent logos and you want to improve removal quality on intricate patterns.
 * 3. When integrating Aspose.Imaging into a C# application to clean scanned documents that have watermarks overlapping text.
 * 4. When you want to customize the MaxPaintingAttempts setting to balance performance and visual fidelity during watermark removal.
 * 5. When generating clean assets for a web gallery and must remove watermarks without manually editing each image.
 */
