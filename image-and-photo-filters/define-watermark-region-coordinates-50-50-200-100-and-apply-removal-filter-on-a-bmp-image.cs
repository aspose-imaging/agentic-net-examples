using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (null‑safe)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the BMP image
            using (var image = Image.Load(inputPath))
            {
                var bmpImage = (BmpImage)image;

                // Define watermark mask (rectangle at 50,50 with width 200 and height 100)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                // Create Telea watermark removal options with the mask
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Apply watermark removal
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options))
                {
                    // Save the resulting image as BMP
                    result.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to automatically clean scanned BMP invoices by removing a logo watermark located at coordinates (50,50,200,100) before archiving them.
 * 2. When a C# application must prepare legacy BMP assets for a game engine by erasing a developer‑added watermark in a fixed rectangle to meet publishing guidelines.
 * 3. When an enterprise document‑management system processes batches of BMP scans and uses Aspose.Imaging’s Telea watermark removal to strip confidential watermarks from a predefined region for internal review.
 * 4. When a .NET photo‑editing tool offers a “Remove Watermark” feature that targets a rectangular area (50,50,200,100) on BMP images without affecting the rest of the picture.
 * 5. When a quality‑control script validates product label BMP images and removes a test‑pattern watermark placed at known coordinates to generate clean samples for machine‑learning training.
 */