using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(0, 0, rasterImage.Width, rasterImage.Height)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                using (RasterImage result = WatermarkRemover.PaintOver(rasterImage, options))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When processing multi‑gigabyte TIFF scans of architectural blueprints on a web server, a developer can set MaxPaintingAttempts to 1 to ensure the watermark removal completes quickly without exhausting CPU resources.
 * 2. In a nightly batch job that cleans up thousands of scanned legal documents stored as TIFF images, limiting MaxPaintingAttempts to 1 prevents long‑running tasks from delaying subsequent jobs.
 * 3. For a desktop C# application that lets users preview edited medical images in real time, using MaxPaintingAttempts = 1 speeds up the removal of diagnostic watermarks on large DICOM‑converted TIFF files.
 * 4. When deploying an Azure Function that automatically strips watermarks from uploaded TIFF photographs, setting MaxPaintingAttempts to 1 keeps the function execution within the platform’s time limits.
 * 5. In a cloud‑based document management system that indexes high‑resolution TIFF maps, developers can use MaxPaintingAttempts = 1 to reduce processing latency while still achieving acceptable content‑aware fill results.
 */