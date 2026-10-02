// HOW-TO: Remove Watermark From Specific Region In BMP Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);
                var result = WatermarkRemover.PaintOver(rasterImage, options);

                result.Save(outputPath, new BmpOptions());

                result.Dispose();
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
 * 1. When a developer needs to automatically erase a logo or text watermark that appears only in a known rectangular area of a BMP file before further image analysis.
 * 2. When an application must clean scanned documents saved as BMPs by removing embedded watermarks located at fixed coordinates to improve OCR accuracy.
 * 3. When a batch‑processing tool processes legacy BMP assets and must strip watermarks from a defined region without affecting the rest of the image.
 * 4. When a photo‑editing service offers a feature to hide watermarks placed at a specific spot in BMP images uploaded by users.
 * 5. When a quality‑control system validates product images and removes watermarks from a preset area to compare the underlying graphics against a reference.
 */
