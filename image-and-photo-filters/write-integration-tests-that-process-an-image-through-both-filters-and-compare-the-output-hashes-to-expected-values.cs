using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "sample.png";
        string medianOutputPath = "sample.median.png";
        string sharpenOutputPath = "sample.sharpen.png";

        // Input validation
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(medianOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(sharpenOutputPath));

        // Expected SHA256 hashes (replace with actual expected values)
        const string expectedMedianHash = "EXPECTED_MEDIAN_HASH";
        const string expectedSharpenHash = "EXPECTED_SHARPEN_HASH";

        // Process Median Filter
        using (Image image = Image.Load(inputPath))
        {
            var raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
            raster.Save(medianOutputPath);
        }

        // Process Sharpen Filter
        using (Image image = Image.Load(inputPath))
        {
            var raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(sharpenOutputPath);
        }

        // Compute SHA256 hashes
        string medianHash = BitConverter.ToString(System.Security.Cryptography.SHA256.Create()
            .ComputeHash(File.ReadAllBytes(medianOutputPath))).Replace("-", "").ToLowerInvariant();

        string sharpenHash = BitConverter.ToString(System.Security.Cryptography.SHA256.Create()
            .ComputeHash(File.ReadAllBytes(sharpenOutputPath))).Replace("-", "").ToLowerInvariant();

        // Compare hashes
        Console.WriteLine($"Median Filter Hash Match: {medianHash == expectedMedianHash}");
        Console.WriteLine($"Sharpen Filter Hash Match: {sharpenHash == expectedSharpenHash}");
    }
}