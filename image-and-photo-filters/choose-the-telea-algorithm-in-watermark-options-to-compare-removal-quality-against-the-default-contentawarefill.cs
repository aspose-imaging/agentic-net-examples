// HOW-TO: Compare Telea and ContentAwareFill Watermark Removal Quality in C# (Aspose.Imaging for .NET)
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
            string outputTeleaPath = "output_telea.png";
            string outputContentAwarePath = "output_contentaware.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputContentAwarePath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define mask
                GraphicsPath mask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
                mask.AddFigure(figure);

                // Telea algorithm
                var teleaOptions = new TeleaWatermarkOptions(mask);
                using (RasterImage teleaResult = WatermarkRemover.PaintOver(image, teleaOptions))
                {
                    teleaResult.Save(outputTeleaPath);
                }

                // ContentAwareFill algorithm (default)
                var cafOptions = new ContentAwareFillWatermarkOptions(mask) { MaxPaintingAttempts = 4 };
                using (RasterImage cafResult = WatermarkRemover.PaintOver(image, cafOptions))
                {
                    cafResult.Save(outputContentAwarePath);
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
 * 1. When you need to compare how the Telea algorithm and the default ContentAwareFill restore a removed watermark in a PNG file.
 * 2. When you want to generate side‑by‑side before‑and‑after images to decide which inpainting method produces higher visual quality for product photos.
 * 3. When you are creating an automated C# workflow that selects the best watermark‑removal technique based on the results of Telea versus ContentAwareFill.
 * 4. When you need to test the effect of an elliptical mask on the inpainting performance of raster images using Aspose.Imaging.
 * 5. When you are preparing demonstration samples for clients to show the difference between Telea and ContentAwareFill watermark removal in .NET applications.
 */
