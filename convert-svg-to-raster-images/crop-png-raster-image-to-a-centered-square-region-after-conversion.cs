// HOW-TO: Crop PNG Image To Centered Square Region In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.png";
        string outputPath = "Output\\cropped.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                int side = Math.Min(raster.Width, raster.Height);
                int x = (raster.Width - side) / 2;
                int y = (raster.Height - side) / 2;

                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(x, y, side, side);
                raster.Crop(rect);

                using (var options = new PngOptions())
                {
                    raster.Save(outputPath, options);
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
 * 1. When you need to generate a square thumbnail from user‑uploaded PNG photos for a profile gallery.
 * 2. When you must prepare a centered square PNG for printing on merchandise where only the central area should be visible.
 * 3. When an application requires cropping scanned PNG documents to a uniform square size before further processing.
 * 4. When you want to ensure consistent aspect ratio for PNG assets in a mobile game UI by cropping them to a centered square.
 * 5. When you need to batch‑process PNG screenshots, removing excess borders and saving the result as a new PNG file.
 */
