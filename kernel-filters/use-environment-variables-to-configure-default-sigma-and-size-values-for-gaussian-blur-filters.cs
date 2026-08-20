// HOW-TO: Apply Gaussian Blur to PNG Using Environment Variables in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.GaussianBlur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read environment variables for size and sigma, with defaults
            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIZE");
            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIGMA");

            int size = 5;          // default odd positive size
            double sigma = 4.0;    // default positive sigma

            if (!string.IsNullOrEmpty(sizeEnv) && int.TryParse(sizeEnv, out int parsedSize) && parsedSize > 0 && parsedSize % 2 == 1)
            {
                size = parsedSize;
            }

            if (!string.IsNullOrEmpty(sigmaEnv) && double.TryParse(sigmaEnv, out double parsedSigma) && parsedSigma > 0)
            {
                sigma = parsedSigma;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter with configured parameters
                var blurOptions = new GaussianBlurFilterOptions(size, sigma);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When you need to automatically blur images in a CI pipeline and want the blur radius and sigma to be configurable without changing code.
 * 2. When processing user‑uploaded PNG files on a server and you want to adjust the Gaussian blur strength via environment settings for different deployment environments.
 * 3. When creating a batch job that applies a consistent blur effect to a folder of images and you need to change the filter size without recompiling the application.
 * 4. When integrating Aspose.Imaging into a microservice that must read blur parameters from container environment variables for dynamic runtime configuration.
 * 5. When building a desktop tool that lets administrators set default Gaussian blur parameters through OS environment variables to standardize image preprocessing.
 */
