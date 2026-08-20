// HOW-TO: Remove Watermark from Specific Region in BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (null-safe)
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
                // Cast to RasterImage for watermark removal
                var raster = (RasterImage)image;

                // Define watermark region (x=50, y=50, width=200, height=100)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                // Create Telea algorithm options with the mask
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Apply watermark removal
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
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
 * 1. When you need to automatically erase a logo or text that appears in a known rectangular area of a BMP file.
 * 2. When processing scanned documents where a watermark was added during scanning and must be removed before OCR.
 * 3. When preparing legacy BMP assets for a web gallery and want to clean up embedded watermarks without manual editing.
 * 4. When building a batch tool that cleans up watermarked screenshots captured from a software demo.
 * 5. When integrating image cleanup into a C# application that receives BMP images from a third‑party system and requires the watermark region to be removed programmatically.
 */
