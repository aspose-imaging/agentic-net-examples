using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // For APNG handling

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.apng";
        string medianOutputPath = @"C:\Images\output.median.apng";
        string wienerOutputPath = @"C:\Images\output.wiener.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(medianOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(wienerOutputPath));

        // Apply Median filter
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (APNG is handled as a raster image)
            RasterImage rasterImage = (RasterImage)image;

            // Apply median filter with size 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the result as APNG (using PngOptions with default settings)
            rasterImage.Save(medianOutputPath, new PngOptions());
        }

        // Apply Gauss-Wiener filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gauss-Wiener filter with radius 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the result as APNG
            rasterImage.Save(wienerOutputPath, new PngOptions());
        }
    }
}