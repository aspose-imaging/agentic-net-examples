// HOW-TO: Apply Motion Blur Followed by Sharpen Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

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
                RasterImage raster = (RasterImage)image;

                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 45.0));

                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                raster.Save(outputPath);
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
 * 1. When you need to simulate camera shake on a PNG and then restore edge detail for a product photo in a C# application.
 * 2. When preparing frames for a video game sprite sheet where a motion‑blur effect must be applied before sharpening to keep the character crisp.
 * 3. When cleaning up scanned documents that appear blurry by first applying a motion‑blur filter to reduce noise and then sharpening to improve readability using Aspose.Imaging in .NET.
 * 4. When generating stylized thumbnails that require a directional blur followed by a 5×5 sharpen to enhance visual impact in a web service.
 * 5. When processing batch images in an automated pipeline that need consistent motion‑blur and sharpening steps before saving them to a specific output folder.
 */
