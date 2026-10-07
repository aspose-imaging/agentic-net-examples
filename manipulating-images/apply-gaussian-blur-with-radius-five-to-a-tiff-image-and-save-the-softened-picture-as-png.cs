// HOW-TO: Apply Gaussian Blur Radius 5 to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 5);
                raster.Filter(raster.Bounds, blurOptions);
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
 * 1. When you need to soften high‑resolution scanned documents (TIFF) before embedding them in a web page as PNGs.
 * 2. When you want to reduce visual noise in medical imaging TIFF files by applying a Gaussian blur and then export them to PNG for reporting.
 * 3. When preparing product catalog images, you may blur the background of a TIFF photograph and save the result as a PNG thumbnail.
 * 4. When converting archival TIFF maps to PNG while applying a blur to hide sensitive details for public distribution.
 * 5. When automating a batch process that applies a radius‑5 Gaussian blur to TIFF graphics and stores the softened output as PNG files for mobile apps.
 */
