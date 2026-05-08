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

            // Read configuration from environment variables
            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIZE");
            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIGMA");

            // Default values
            int size = 5;          // must be positive odd integer
            double sigma = 4.0;    // must be positive non‑zero

            // Parse size if provided and valid
            if (!string.IsNullOrEmpty(sizeEnv) &&
                int.TryParse(sizeEnv, out int parsedSize) &&
                parsedSize > 0 && parsedSize % 2 == 1)
            {
                size = parsedSize;
            }

            // Parse sigma if provided and valid
            if (!string.IsNullOrEmpty(sigmaEnv) &&
                double.TryParse(sigmaEnv, out double parsedSigma) &&
                parsedSigma > 0)
            {
                sigma = parsedSigma;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter to the whole image
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