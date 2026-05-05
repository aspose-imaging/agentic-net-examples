using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "sample.png";
            string sharpenOutputPath = "sharpened.png";
            string gaussianOutputPath = "gaussian.png";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(sharpenOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(gaussianOutputPath));

            // Expected simple checksums (replace with real values)
            const int expectedSharpenChecksum = 123456789;
            const int expectedGaussianChecksum = 987654321;

            // Apply Sharpen filter
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                raster.Save(sharpenOutputPath);
            }

            // Compute checksum for Sharpen output
            byte[] sharpenBytes = File.ReadAllBytes(sharpenOutputPath);
            int sharpenChecksum = sharpenBytes.Aggregate(0, (a, b) => (a * 31 + b) & 0x7fffffff);
            Console.WriteLine($"Sharpen checksum: {sharpenChecksum}");
            Console.WriteLine(sharpenChecksum == expectedSharpenChecksum ? "Sharpen test passed." : "Sharpen test failed.");

            // Apply Gaussian Blur filter
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(gaussianOutputPath);
            }

            // Compute checksum for Gaussian output
            byte[] gaussianBytes = File.ReadAllBytes(gaussianOutputPath);
            int gaussianChecksum = gaussianBytes.Aggregate(0, (a, b) => (a * 31 + b) & 0x7fffffff);
            Console.WriteLine($"Gaussian checksum: {gaussianChecksum}");
            Console.WriteLine(gaussianChecksum == expectedGaussianChecksum ? "Gaussian test passed." : "Gaussian test failed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}