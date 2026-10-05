// HOW-TO: Remove Watermark From JPEG Using Content Aware Fill In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.jpg";
            string outputPath = "Output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                using (var result = WatermarkRemover.PaintOver(raster, options))
                {
                    var jpegOptions = new JpegOptions();
                    result.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically erase a logo watermark from product photos in JPEG format before publishing them online.
 * 2. When you must clean up scanned receipts that contain timestamp watermarks as part of a C# batch‑processing workflow.
 * 3. When you want to prepare archival JPEG images for printing by programmatically removing photographer watermarks while preserving quality.
 * 4. When you are building a C# web service that receives user‑uploaded JPEGs and must strip promotional watermarks using a content‑aware fill algorithm.
 * 5. When you need to remove a watermark from a JPEG with limited painting attempts (e.g., three) to balance processing time and visual fidelity.
 */
