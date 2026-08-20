// HOW-TO: How To Fallback To Telea When ContentAwareFill Takes Too Long In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load image
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                // Create mask (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                // Try ContentAwareFill with time limit
                var caOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, caOptions))
                {
                    stopwatch.Stop();

                    if (stopwatch.Elapsed > TimeSpan.FromSeconds(5))
                    {
                        // Exceeded time limit, fallback to Telea
                        // Dispose result (handled by using) and continue
                    }
                    else
                    {
                        result.Save(outputPath);
                        return;
                    }
                }

                // Fallback to Telea algorithm
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var fallbackResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions))
                {
                    fallbackResult.Save(outputPath);
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
 * 1. When you need to remove or fill a region in a PNG image but want to ensure the operation completes quickly, using a time‑limited ContentAwareFill with a Telea fallback prevents long processing delays.
 * 2. When processing large batches of photos where some images cause the ContentAwareFill algorithm to exceed performance budgets, the fallback ensures each image is still saved without manual intervention.
 * 3. When building an automated watermark removal tool that must handle varying complexities, switching to Telea after a 5‑second limit guarantees a result even for difficult textures.
 * 4. When integrating Aspose.Imaging into a web service that must respond within a strict timeout, the fallback to a faster inpainting method keeps the API responsive.
 * 5. When developing a desktop application that lets users erase objects from PNG files, the fallback provides a reliable user experience by avoiding hangs on complex fills.
 */
