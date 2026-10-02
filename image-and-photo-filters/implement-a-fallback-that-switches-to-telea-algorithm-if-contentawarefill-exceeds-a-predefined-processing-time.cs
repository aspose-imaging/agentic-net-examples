// HOW-TO: Fallback to Telea Watermark Removal When ContentAwareFill Exceeds Time Limit in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10, 10, 100, 100)));
                mask.AddFigure(figure);

                TimeSpan timeLimit = TimeSpan.FromSeconds(5);
                RasterImage processedImage = null;

                var contentOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                DateTime start = DateTime.Now;
                processedImage = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, contentOptions);
                TimeSpan elapsed = DateTime.Now - start;

                if (elapsed > timeLimit)
                {
                    processedImage.Dispose();
                    var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                    processedImage = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, teleaOptions);
                }

                processedImage.Save(outputPath);
                processedImage.Dispose();
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
 * 1. When you need to remove a watermark from a PNG but want to ensure the operation finishes quickly by switching to the faster Telea algorithm if the ContentAwareFill method runs longer than a set threshold.
 * 2. When processing large images where the ContentAwareFill algorithm may exceed performance budgets, and you require an automatic fallback to maintain responsive batch processing.
 * 3. When building an image‑editing service that must guarantee a result within a specific time window, using a timed fallback prevents time‑outs while still attempting the higher‑quality fill first.
 * 4. When integrating Aspose.Imaging into a C# application that handles user‑uploaded photos and you need to protect server resources by limiting the processing time of advanced watermark removal.
 * 5. When you want to programmatically choose between two watermark‑removal techniques—ContentAwareFill for quality and Telea for speed—based on real‑time execution duration.
 */
