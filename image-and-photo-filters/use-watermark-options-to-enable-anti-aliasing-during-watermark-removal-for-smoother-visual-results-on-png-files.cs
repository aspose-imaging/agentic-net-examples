// HOW-TO: Remove Watermark From PNG With Anti‑Aliasing Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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
                int width = raster.Width;
                int height = raster.Height;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, width, height)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);

                using (var result = WatermarkRemover.PaintOver(raster, options))
                {
                    result.Save(outputPath, new PngOptions());
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
 * 1. When you need to clean up scanned PNG documents that contain faint watermarks and want smooth edges after removal.
 * 2. When an e‑commerce platform must automatically strip promotional watermarks from product PNG images while preserving visual quality.
 * 3. When a digital archivist wants to restore legacy PNG graphics by removing embedded logos without introducing jagged artifacts.
 * 4. When a mobile app processes user‑uploaded PNG screenshots and must eliminate watermarks with anti‑aliasing to keep the UI crisp.
 * 5. When a batch script converts watermarked PNG assets to clean versions for printing, using Aspose.Imaging’s TeleaWatermarkOptions for smoother results.
 */
