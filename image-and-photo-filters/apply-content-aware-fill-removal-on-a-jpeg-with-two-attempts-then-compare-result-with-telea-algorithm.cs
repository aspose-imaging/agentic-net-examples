// HOW-TO: Apply Content-Aware Fill and Telea Watermark Removal on JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPathTelea = "output/telea.jpg";
        string outputPathCA = "output/ca.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathCA));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                var resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions);
                resultTelea.Save(outputPathTelea);
                resultTelea.Dispose();

                var caOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };
                var resultCA = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, caOptions);
                resultCA.Save(outputPathCA);
                resultCA.Dispose();
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
 * 1. When you need to automatically erase a rectangular watermark from a JPEG and compare two inpainting methods (Content-Aware Fill vs Telea) in a C# application.
 * 2. When you want to generate a clean version of a product photo by removing a logo using Aspose.Imaging's ContentAwareFill with limited painting attempts.
 * 3. When you are evaluating which inpainting algorithm gives better visual results for restoring missing image areas in .NET.
 * 4. When you need to batch‑process images, saving both the Telea‑based and Content‑Aware‑Fill‑based results to separate output folders.
 * 5. When you must handle missing files or directory creation gracefully while performing watermark removal on JPEG images in C#.
 */
