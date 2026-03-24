using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string medianOutputPath = @"C:\Images\output_median.png";
        string wienerOutputPath = @"C:\Images\output_wiener.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(medianOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(wienerOutputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage rasterImage = (RasterImage)image;

            // ---------- Median Filter ----------
            // Apply a median filter with a kernel size of 5 to the whole image
            var medianOptions = new MedianFilterOptions(5);
            rasterImage.Filter(rasterImage.Bounds, medianOptions);
            // Save the median‑filtered image
            rasterImage.Save(medianOutputPath);
        }

        // Reload the original image for the Wiener filter (to avoid cumulative effects)
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // ---------- Gauss‑Wiener Filter ----------
            // Apply a Gauss‑Wiener filter with radius 5 and sigma 4.0
            var wienerOptions = new GaussWienerFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, wienerOptions);
            // Save the Wiener‑filtered image
            rasterImage.Save(wienerOutputPath);
        }
    }
}