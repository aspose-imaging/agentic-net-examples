using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputMedianPath = @"C:\Images\output.median.png";
        string outputWienerPath = @"C:\Images\output.wiener.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputWienerPath));

        // Apply Median filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;
            var medianOptions = new MedianFilterOptions(5); // rectangle size = 5
            rasterImage.Filter(rasterImage.Bounds, medianOptions);
            rasterImage.Save(outputMedianPath);
        }

        // Apply Gauss-Wiener filter (Wiener filter)
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;
            var wienerOptions = new GaussWienerFilterOptions(5, 4.0); // radius = 5, sigma = 4.0
            rasterImage.Filter(rasterImage.Bounds, wienerOptions);
            rasterImage.Save(outputWienerPath);
        }
    }
}