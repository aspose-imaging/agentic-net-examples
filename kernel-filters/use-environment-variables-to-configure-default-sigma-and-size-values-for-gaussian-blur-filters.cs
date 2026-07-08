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

            // Default filter parameters
            int size = 5;          // must be positive odd
            double sigma = 4.0;    // must be positive

            // Override with environment variables if present and valid
            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");
            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");

            if (!string.IsNullOrEmpty(sizeEnv) && int.TryParse(sizeEnv, out int parsedSize) && parsedSize > 0 && parsedSize % 2 == 1)
                size = parsedSize;

            if (!string.IsNullOrEmpty(sigmaEnv) && double.TryParse(sigmaEnv, out double parsedSigma) && parsedSigma > 0)
                sigma = parsedSigma;

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter with the configured size and sigma
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(size, sigma));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a CI/CD pipeline needs to apply a configurable Gaussian blur to PNG assets without changing source code, developers can set GAUSSIAN_SIZE and GAUSSIAN_SIGMA environment variables to control the filter at build time.
 * 2. When a desktop application processes user‑uploaded images and must allow system administrators to define default blur strength for privacy masking, the code reads GAUSSIAN_SIZE and GAUSSIAN_SIGMA from the environment to apply the Aspose.Imaging GaussianBlurFilterOptions.
 * 3. When a batch job runs on a Linux server to preprocess a large collection of PNG files for machine‑learning training, using environment variables lets the job dynamically adjust the blur radius and sigma without recompiling the C# program.
 * 4. When an automated testing framework validates image‑processing quality across different devices, testers can inject different sigma and size values via GAUSSIAN_SIZE and GAUSSIAN_SIGMA to simulate varying blur levels.
 * 5. When a microservice that serves transformed images needs to honor runtime configuration for blur intensity, reading the environment variables ensures the Aspose.Imaging RasterImage filter uses the correct size and sigma for each request.
 */