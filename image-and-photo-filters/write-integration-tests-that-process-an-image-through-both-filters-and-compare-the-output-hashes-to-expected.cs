// HOW-TO: Validate Gaussian Blur and Sharpen Filters Output Hashes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath1 = "output_gaussian.png";
            string outputPath2 = "output_sharpen.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var gaussianOptions = new GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, gaussianOptions);
                var pngOptions = new PngOptions();
                raster.Save(outputPath1, pngOptions);
            }

            using (Image image2 = Image.Load(inputPath))
            {
                RasterImage raster2 = (RasterImage)image2;
                var sharpenOptions = new SharpenFilterOptions();
                sharpenOptions.Sigma = 1.0;
                raster2.Filter(raster2.Bounds, sharpenOptions);
                var pngOptions2 = new PngOptions();
                raster2.Save(outputPath2, pngOptions2);
            }

            string hash1 = ComputeHash(outputPath1);
            string hash2 = ComputeHash(outputPath2);

            const string expectedHash1 = "EXPECTED_HASH_GAUSSIAN";
            const string expectedHash2 = "EXPECTED_HASH_SHARPEN";

            Console.WriteLine($"Gaussian hash match: {hash1.Equals(expectedHash1, StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($"Sharpen hash match: {hash2.Equals(expectedHash2, StringComparison.OrdinalIgnoreCase)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ComputeHash(string filePath)
    {
        using (var stream = File.OpenRead(filePath))
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var hash = sha256.ComputeHash(stream);
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure that applying a Gaussian blur filter to a PNG image produces a consistent hash for regression testing.
 * 2. When you want to automatically verify that a sharpen filter modifies an image as expected by comparing its hash to a known value.
 * 3. When you are building a CI pipeline that runs integration tests on Aspose.Imaging filter operations to catch image‑processing regressions.
 * 4. When you must generate reference PNG files after filtering for visual inspection or downstream processing in a .NET application.
 * 5. When you need to confirm that your C# code using Aspose.Imaging correctly handles raster image filters before deploying to production.
 */
