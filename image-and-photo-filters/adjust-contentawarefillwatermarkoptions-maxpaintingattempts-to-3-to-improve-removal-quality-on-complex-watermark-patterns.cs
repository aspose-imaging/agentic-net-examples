using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                var result = WatermarkRemover.PaintOver(pngImage, options);
                result.Save(outputPath);
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
 * 1. When a developer needs to clean up a PNG image that contains a semi‑transparent logo or watermark with intricate shapes, they can use ContentAwareFillWatermarkOptions.MaxPaintingAttempts set to 3 to achieve higher quality removal.
 * 2. When processing scanned documents saved as PNG files where the watermark pattern includes overlapping curves, increasing MaxPaintingAttempts to 3 helps the WatermarkRemover.PaintOver algorithm converge on a smoother background.
 * 3. When building an automated image‑preprocessing pipeline for e‑commerce product photos that contain complex watermark patterns, setting MaxPaintingAttempts to 3 ensures the content‑aware fill produces a clean result without manual touch‑up.
 * 4. When integrating Aspose.Imaging into a C# desktop application that lets users erase watermarks from PNG screenshots with detailed graphics, configuring MaxPaintingAttempts to 3 improves the visual fidelity of the restored area.
 * 5. When developing a batch script that removes brand watermarks from a large collection of PNG assets with varying opacity and shape complexity, adjusting MaxPaintingAttempts to 3 reduces artifacts and speeds up the content‑aware fill process.
 */