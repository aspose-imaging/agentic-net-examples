// HOW-TO: How To Improve Watermark Removal Smoothness By Increasing MaxPaintingAttempts In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputDir = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                // Cast to specific raster image type
                var pngImage = (PngImage)image;

                // Define a simple elliptical mask
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                // Test different MaxPaintingAttempts values
                int[] attempts = new int[] { 2, 4, 8 };
                foreach (var attempt in attempts)
                {
                    // Higher MaxPaintingAttempts can produce smoother fill results
                    var options = new ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = attempt
                    };

                    // Perform watermark removal (content-aware fill)
                    using (var result = WatermarkRemover.PaintOver(pngImage, options))
                    {
                        string outPath = Path.Combine(outputDir, $"result_{attempt}.png");
                        result.Save(outPath);
                    }
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
 * 1. When you need to remove a logo or watermark from a PNG image while keeping the surrounding area visually smooth.
 * 2. When you want to compare different MaxPaintingAttempts values to determine which setting yields the highest quality content‑aware fill.
 * 3. When you are creating an automated batch process that cleans scanned documents by erasing watermarks with minimal visual artifacts.
 * 4. When you need to generate multiple versions of a cleaned image to evaluate how painting attempts affect edge continuity and texture.
 * 5. When you are integrating Aspose.Imaging into a C# application to programmatically restore photo regions obscured by watermarks.
 */
