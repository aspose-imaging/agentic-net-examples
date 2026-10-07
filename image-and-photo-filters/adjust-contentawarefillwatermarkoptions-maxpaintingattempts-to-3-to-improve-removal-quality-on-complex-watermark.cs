// HOW-TO: Remove Watermark From JPEG Using ContentAwareFill And MaxPaintingAttempts 3 In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
                var raster = (RasterImage)image;

                var points = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(raster.Width - 1, 0),
                    new Aspose.Imaging.Point(raster.Width - 1, raster.Height - 1),
                    new Aspose.Imaging.Point(0, raster.Height - 1)
                };

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(points)
                {
                    MaxPaintingAttempts = 3
                };

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    result.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to automatically erase a complex logo or text watermark from JPEG photos before archiving them.
 * 2. When an e‑commerce application must clean up product JPEG images that contain semi‑transparent watermarks to improve visual quality.
 * 3. When a batch‑processing tool has to remove watermarks from user‑uploaded JPEGs while preserving the original dimensions and format.
 * 4. When a digital asset management system requires watermark removal with a limited number of painting attempts to balance speed and quality.
 * 5. When a C# service integrates Aspose.Imaging to restore copyrighted JPEG images by stripping watermarks without converting to another file type.
 */
