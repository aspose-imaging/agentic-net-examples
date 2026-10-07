// HOW-TO: Compare Telea Vs ContentAwareFill Watermark Removal In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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
            string outputPathTelea = "output/telea.png";
            string outputPathContent = "output/content.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create mask (example rectangle)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Process with Telea algorithm
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                var teleaOptions = new TeleaWatermarkOptions(mask);
                using (var resultTelea = WatermarkRemover.PaintOver(raster, teleaOptions))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));
                    resultTelea.Save(outputPathTelea);
                }
            }

            // Process with default ContentAwareFill algorithm
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                var contentOptions = new ContentAwareFillWatermarkOptions(mask);
                using (var resultContent = WatermarkRemover.PaintOver(raster, contentOptions))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPathContent));
                    resultContent.Save(outputPathContent);
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
 * 1. When you need to evaluate which algorithm produces cleaner results for removing a rectangular watermark from a PNG image in a .NET application.
 * 2. When you want to generate side‑by‑side outputs to benchmark Telea and ContentAwareFill performance on the same source file.
 * 3. When you are building an automated pipeline that selects the best in‑painting method based on visual quality of the restored area.
 * 4. When you must ensure the output directories exist before saving processed images while handling missing input files gracefully.
 * 5. When you are testing Aspose.Imaging’s watermark removal APIs with custom masks to verify compatibility with different image formats such as PNG or JPEG.
 */
