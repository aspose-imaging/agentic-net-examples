using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string teleaOutputPath = "output_telea.png";
        string contentOutputPath = "output_content.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(teleaOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(contentOutputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    teleaResult.Save(teleaOutputPath);
                }

                var contentOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var contentResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, contentOptions))
                {
                    contentResult.Save(contentOutputPath);
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
 * 1. When a developer needs to automatically remove a circular watermark from a PNG photograph and compare the visual quality of the Telea inpainting algorithm against the default ContentAwareFill method.
 * 2. When building a batch image‑processing tool that cleans up scanned documents by masking specific regions and evaluating which algorithm (Telea vs ContentAwareFill) preserves text readability best.
 * 3. When creating a web service that receives user‑uploaded PNG images, removes logo overlays using a custom mask, and selects the optimal algorithm based on side‑by‑side output comparison.
 * 4. When integrating Aspose.Imaging into a C# desktop application to restore old product images by painting over watermarks and measuring the impact of MaxPaintingAttempts on the ContentAwareFill result.
 * 5. When testing image‑processing pipelines for e‑commerce platforms, developers can use this code to benchmark TeleaWatermarkOptions versus ContentAwareFillWatermarkOptions for consistent background reconstruction.
 */