// HOW-TO: Remove Watermark from PNG Using Elliptical Mask and ContentAwareFill in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main()
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);

                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);
                using (result)
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
 * 1. When you need to automatically erase a semi‑transparent logo from a PNG product photo before publishing it on an e‑commerce site.
 * 2. When you must clean scanned PNG receipts that contain a faint watermark so they can be processed by an OCR engine.
 * 3. When you want to remove a circular watermark from screenshots of a software demo to create a clean presentation slide.
 * 4. When you are preparing a batch of PNG assets for a mobile app and need to strip out test watermarks without manually selecting each region.
 * 5. When you have a PNG map image with an elliptical copyright stamp and need to replace it using Aspose.Imaging’s ContentAwareFill algorithm.
 */
