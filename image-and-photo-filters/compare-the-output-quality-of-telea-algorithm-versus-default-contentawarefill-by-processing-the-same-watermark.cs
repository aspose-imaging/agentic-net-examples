// HOW-TO: Compare Telea vs Content Aware Fill Watermark Removal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/watermark.png";
            string outputTeleaPath = "output/telea_result.png";
            string outputCafPath = "output/contentaware_result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Create a mask using an ellipse shape
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // ----- Telea algorithm -----
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    teleaResult.Save(outputTeleaPath);
                }

                // ----- Content Aware Fill algorithm (default) -----
                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, cafOptions))
                {
                    cafResult.Save(outputCafPath);
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
 * 1. When you need to evaluate which algorithm—Telea or Content Aware Fill—produces better results for removing a logo from a PNG photograph in a C# application.
 * 2. When you want to automatically generate a mask using an ellipse shape to target a specific region of a watermark before applying Aspose.Imaging’s removal tools.
 * 3. When you are building a batch process that saves the original image alongside separate outputs for Telea and default Content Aware Fill to compare visual quality.
 * 4. When you must ensure output directories exist and handle missing input files gracefully while performing watermark removal in .NET.
 * 5. When you require fine‑tuning of the Content Aware Fill algorithm, such as limiting painting attempts, to balance speed and quality in a C# image‑processing pipeline.
 */
