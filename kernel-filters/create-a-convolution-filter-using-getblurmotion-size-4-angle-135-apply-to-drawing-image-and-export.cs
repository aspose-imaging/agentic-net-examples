// HOW-TO: Apply Motion Blur Filter to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(4, 135));

                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to add a diagonal motion‑blur effect to a PNG before publishing it on a website.
 * 2. When you want to programmatically enhance scanned documents by simulating camera shake using a 4‑pixel, 135° blur in a .NET application.
 * 3. When you are building an image‑processing pipeline that must apply a custom convolution filter to raster images for artistic rendering.
 * 4. When you need to generate blurred thumbnails of PNG assets automatically during a build process with Aspose.Imaging for C#.
 * 5. When you are creating a batch job that reads PNG files, applies a motion blur filter, and saves the results to a specific output folder.
 */
