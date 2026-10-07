// HOW-TO: Apply Gaussian Blur Followed By Sharpen To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var gaussOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, gaussOptions);

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                raster.Filter(raster.Bounds, sharpenOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce noise in a PNG screenshot before enhancing edges for a web thumbnail.
 * 2. When preparing product photos for an e‑commerce site, applying blur to soften background then sharpening the subject.
 * 3. When processing scanned documents to smooth artifacts and then improve text clarity in a C# application.
 * 4. When creating stylized graphics where a subtle blur is applied first and a sharpen filter refines details.
 * 5. When automating batch image cleanup in a .NET service, combining Gaussian blur and sharpen to improve visual quality of PNG assets.
 */
