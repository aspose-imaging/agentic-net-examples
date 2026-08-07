using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "watermark.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputTelea = "output_telea.png";
            string outputCaf = "output_caf.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputTelea));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCaf));

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define the mask region (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // ----- Telea algorithm -----
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    resultTelea.Save(outputTelea);
                }

                // ----- Content Aware Fill algorithm -----
                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var resultCaf = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, cafOptions))
                {
                    resultCaf.Save(outputCaf);
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
 * 1. When a developer needs to evaluate which in‑painting algorithm (Telea vs Content‑Aware Fill) produces the most natural result for removing a logo from a PNG watermark using an elliptical mask.
 * 2. When a C# application must automatically compare the visual quality of Telea and default ContentAwareFill after processing the same watermark image to choose the optimal algorithm for batch image cleanup.
 * 3. When a software engineer wants to benchmark Aspose.Imaging’s TeleaWatermarkOptions against ContentAwareFillWatermarkOptions on a PNG file to decide which method preserves background texture better.
 * 4. When an image‑processing pipeline requires side‑by‑side output files (output_telea.png and output_caf.png) to demonstrate to non‑technical stakeholders the difference between the two algorithms.
 * 5. When a developer is integrating Aspose.Imaging’s WatermarkRemover into a .NET project and needs to verify that the MaxPaintingAttempts setting in ContentAwareFill does not degrade quality compared with the Telea algorithm.
 */