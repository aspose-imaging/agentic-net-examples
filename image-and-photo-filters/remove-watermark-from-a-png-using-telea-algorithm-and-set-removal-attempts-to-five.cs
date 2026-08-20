// HOW-TO: Remove Watermark from PNG Using Telea Algorithm in C# (Aspose.Imaging for .NET)
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

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                // Example ellipse mask; adjust coordinates as needed
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);
                // Telea algorithm does not support setting removal attempts; property not available.

                using (var result = WatermarkRemover.PaintOver(pngImage, options))
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
 * 1. When you need to automatically erase a logo or text overlay from scanned PNG photos before archiving them.
 * 2. When a web service must clean up user‑uploaded PNG images by removing watermarks using Aspose.Imaging’s Telea inpainting.
 * 3. When a batch processing tool has to restore original PNG graphics after a watermark was added for preview purposes.
 * 4. When you want to programmatically hide confidential markings on PNG screenshots while preserving image quality.
 * 5. When integrating image cleanup into a C# application that receives PNG files with elliptical watermarks and requires in‑place removal.
 */
