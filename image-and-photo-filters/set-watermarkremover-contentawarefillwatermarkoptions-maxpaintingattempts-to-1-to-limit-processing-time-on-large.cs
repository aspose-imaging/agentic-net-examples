// HOW-TO: Limit Watermark Removal Processing Time on Large TIFFs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\result.tif";

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
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);
                using (result)
                {
                    result.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When processing multi‑megapixel TIFF scans and need to remove watermarks quickly without exhausting CPU time.
 * 2. When integrating Aspose.Imaging into a document‑management system that must handle batch watermark removal on large TIFF files within strict performance budgets.
 * 3. When developing a C# service that cleans up scanned legal documents and wants to cap the number of painting attempts to avoid long delays.
 * 4. When optimizing a server‑side image pipeline that receives high‑resolution TIFFs and requires fast watermark erasure to meet SLA response times.
 * 5. When building a desktop utility for archivists that strips watermarks from large TIFF images while ensuring the operation completes promptly.
 */
