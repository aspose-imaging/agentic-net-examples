using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "sample.png";
            string outputMedianPath = "output_median.png";
            string outputSharpenPath = "output_sharpen.png";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputSharpenPath) ?? ".");

            // Apply Median filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                raster.Save(outputMedianPath);
            }

            // Apply Sharpen filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                raster.Save(outputSharpenPath);
            }

            // Compute simple hash for Median output
            long medianHash = File.ReadAllBytes(outputMedianPath)
                                 .Aggregate(0L, (acc, b) => acc * 31 + b);
            long expectedMedianHash = 1234567890L; // replace with actual expected value
            if (medianHash != expectedMedianHash)
                Console.WriteLine($"Median filter hash mismatch: {medianHash}");
            else
                Console.WriteLine("Median filter output matches expected hash.");

            // Compute simple hash for Sharpen output
            long sharpenHash = File.ReadAllBytes(outputSharpenPath)
                                  .Aggregate(0L, (acc, b) => acc * 31 + b);
            long expectedSharpenHash = 987654321L; // replace with actual expected value
            if (sharpenHash != expectedSharpenHash)
                Console.WriteLine($"Sharpen filter hash mismatch: {sharpenHash}");
            else
                Console.WriteLine("Sharpen filter output matches expected hash.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to verify that applying a 5‑pixel Median filter to a PNG image using Aspose.Imaging produces a consistent output across builds, they can run an integration test that saves the filtered image and compares its hash to an expected value.
 * 2. When a CI pipeline must ensure that the Sharpen filter with radius 5 and strength 4.0 does not introduce regressions in raster image processing, the test can generate “output_sharpen.png” and validate its hash against a known checksum.
 * 3. When a team wants to confirm that file‑system handling (checking file existence, creating output directories) works correctly together with image loading and saving in a .NET application, they can use this code as an integration test scenario.
 * 4. When quality assurance requires automated verification that both Median and Sharpen filters produce identical results on the same source image after code refactoring, the hash comparison approach provides a quick, language‑agnostic validation.
 * 5. When a developer is building a cross‑platform image‑processing service and needs to guarantee that the binary output of filtered PNG files remains unchanged after deployment, they can embed this hash‑based test into their unit‑test suite.
 */