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
        string outputPath = "output.GaussianBlur.png";

        // Read environment variables for size and sigma, with fallback defaults
        string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIZE");
        string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_BLUR_SIGMA");

        int size = 5;          // default kernel size (must be positive odd)
        double sigma = 4.0;    // default sigma (must be positive)

        if (int.TryParse(sizeEnv, out int parsedSize) && parsedSize > 0 && parsedSize % 2 == 1)
        {
            size = parsedSize;
        }

        if (double.TryParse(sigmaEnv, out double parsedSigma) && parsedSigma > 0)
        {
            sigma = parsedSigma;
        }

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, apply Gaussian blur, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(size, sigma)
                );
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}