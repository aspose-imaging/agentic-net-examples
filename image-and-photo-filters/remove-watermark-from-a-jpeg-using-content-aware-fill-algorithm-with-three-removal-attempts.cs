// HOW-TO: Remove Watermark from JPEG Using Content Aware Fill in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var jpegImage = (JpegImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, options))
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
 * 1. When you need to automatically erase a logo or text overlay from a JPEG photo before publishing it online.
 * 2. When you want to clean up scanned documents that contain watermarks without manually editing each image.
 * 3. When you are building a batch‑processing tool that removes watermarks from product images for an e‑commerce catalog.
 * 4. When you need to programmatically restore original image content after a watermark was added for temporary protection.
 * 5. When you are developing a C# application that must attempt multiple content‑aware fill passes to improve the quality of watermark removal.
 */
