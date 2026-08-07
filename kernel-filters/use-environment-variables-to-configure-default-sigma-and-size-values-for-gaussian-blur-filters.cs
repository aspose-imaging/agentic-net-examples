using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Read configuration from environment variables
            // Default values are used if variables are missing or invalid
            int size = 5; // default kernel size
            double sigma = 4.0; // default sigma

            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");
            if (int.TryParse(sizeEnv, out int parsedSize) && parsedSize > 0 && parsedSize % 2 == 1)
            {
                size = parsedSize;
            }

            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");
            if (double.TryParse(sigmaEnv, out double parsedSigma) && parsedSigma > 0)
            {
                sigma = parsedSigma;
            }

            // Load the image, apply Gaussian blur, and save the result
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter with configured size and sigma
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
 * 1. When a developer needs to apply a configurable Gaussian blur to PNG images in a CI/CD pipeline, using environment variables to set kernel size and sigma without changing source code.
 * 2. When an automated image‑processing service must adapt blur strength per deployment environment (e.g., staging vs production) by reading GAUSSIAN_SIZE and GAUSSIAN_SIGMA from the host’s environment.
 * 3. When a desktop application processes user‑uploaded photos and wants to let system administrators control default blur parameters via OS environment settings for compliance or performance reasons.
 * 4. When a batch job processes large folders of raster images and the blur kernel dimensions need to be tuned at runtime without recompiling the C# project.
 * 5. When a cloud function using Aspose.Imaging for .NET applies a Gaussian blur to images and the blur intensity must be configurable through container environment variables for easy scaling.
 */