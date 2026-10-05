// HOW-TO: How To Improve Watermark Fill Smoothness By Increasing MaxPaintingAttempts In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.png";
            string outputPathDefault = "output/default.png";
            string outputPathIncreased = "output/increased.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathDefault));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathIncreased));

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                // Default MaxPaintingAttempts
                var optionsDefault = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var resultDefault = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, optionsDefault))
                {
                    resultDefault.Save(outputPathDefault, new PngOptions());
                }

                // Increased MaxPaintingAttempts
                var optionsIncreased = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 10
                };
                using (var resultIncreased = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, optionsIncreased))
                {
                    resultIncreased.Save(outputPathIncreased, new PngOptions());
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
 * 1. When you need to restore a PNG image after removing an elliptical watermark and want a smoother fill, you can increase MaxPaintingAttempts.
 * 2. When processing batch images where the default painting attempts produce visible artifacts, raising MaxPaintingAttempts yields higher visual quality.
 * 3. When generating printable graphics that require a seamless background after watermark removal, adjusting MaxPaintingAttempts helps avoid jagged edges.
 * 4. When integrating Aspose.Imaging into a C# application that dynamically removes watermarks from user‑uploaded photos, you can tune MaxPaintingAttempts for optimal results.
 * 5. When comparing performance versus quality for content‑aware fill, changing MaxPaintingAttempts lets you balance processing time against smoothness.
 */
