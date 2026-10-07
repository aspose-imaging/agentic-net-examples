// HOW-TO: Resize BMP to 1200x1200 and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.bmp";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(1200, 1200, ResizeType.NearestNeighbourResample);

                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to generate a scalable vector version of a legacy BMP logo for responsive web design.
 * 2. When an automated batch process must shrink large BMP scans to a fixed 1200‑pixel square before embedding them in SVG‑based reports.
 * 3. When a desktop application has to convert user‑uploaded BMP drawings into SVG files that can be edited without loss of quality.
 * 4. When a migration script must standardize image assets by resizing BMP textures and saving them as SVG for use in modern UI frameworks.
 * 5. When a CI pipeline requires a quick C# step to transform BMP screenshots into 1200×1200 SVG thumbnails for documentation.
 */
