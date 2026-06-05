using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.png";
        string outputDir = @"C:\Images\output";
        string sharpenOutputPath = Path.Combine(outputDir, "output_sharpen.png");
        string bilateralOutputPath = Path.Combine(outputDir, "output_bilateral.png");

        // Expected SHA256 hashes for the processed images (replace with real values)
        const string expectedSharpenHash = "PLACEHOLDER_SHARPEN_HASH";
        const string expectedBilateralHash = "PLACEHOLDER_BILATERAL_HASH";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sharpenOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(bilateralOutputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // ---------- Sharpen Filter ----------
                // Apply sharpen filter with kernel size 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                // Save the sharpened image
                rasterImage.Save(sharpenOutputPath);
                // Compute hash
                string sharpenHash = ComputeFileHash(sharpenOutputPath);
                // Compare with expected
                Console.WriteLine($"Sharpen filter hash: {sharpenHash}");
                Console.WriteLine(sharpenHash.Equals(expectedSharpenHash, StringComparison.OrdinalIgnoreCase)
                    ? "Sharpen filter output matches expected hash."
                    : "Sharpen filter output does NOT match expected hash.");

                // Reload original image for the next filter to avoid cumulative effects
                rasterImage.Dispose();
                using (Image image2 = Image.Load(inputPath))
                {
                    RasterImage rasterImage2 = (RasterImage)image2;

                    // ---------- Bilateral Smoothing Filter ----------
                    // Apply bilateral smoothing filter with kernel size 5
                    rasterImage2.Filter(rasterImage2.Bounds, new BilateralSmoothingFilterOptions(5));
                    // Save the bilateral filtered image
                    rasterImage2.Save(bilateralOutputPath);
                    // Compute hash
                    string bilateralHash = ComputeFileHash(bilateralOutputPath);
                    // Compare with expected
                    Console.WriteLine($"Bilateral filter hash: {bilateralHash}");
                    Console.WriteLine(bilateralHash.Equals(expectedBilateralHash, StringComparison.OrdinalIgnoreCase)
                        ? "Bilateral filter output matches expected hash."
                        : "Bilateral filter output does NOT match expected hash.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute SHA256 hash of a file and return as hex string
    private static string ComputeFileHash(string filePath)
    {
        using (FileStream stream = File.OpenRead(filePath))
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(stream);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}