// HOW-TO: Align PNG Resolution and Apply Bilateral Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double hRes = image.HorizontalResolution;
                double vRes = image.VerticalResolution;
                double maxRes = Math.Max(hRes, vRes);
                image.HorizontalResolution = maxRes;
                image.VerticalResolution = maxRes;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions();
                image.Filter(image.Bounds, filterOptions);

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, options);
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
 * 1. When you need to standardize the DPI of a PNG image before printing to ensure consistent size across devices.
 * 2. When you want to reduce noise in a PNG while keeping edges sharp for medical imaging or satellite photos.
 * 3. When you must prepare a PNG for a web gallery that requires a uniform resolution without distorting the aspect ratio.
 * 4. When you are building a batch‑processing tool that aligns image resolutions and applies smoothing to improve visual quality.
 * 5. When you need to programmatically save a filtered PNG using Aspose.Imaging with custom file‑creation options.
 */
