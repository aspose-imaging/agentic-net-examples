using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_gaussian.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Retrieve Gaussian blur parameters from environment variables
        // Fallback to defaults if variables are missing or invalid
        const int defaultSize = 5;          // must be positive odd integer
        const double defaultSigma = 4.0;    // must be positive non‑zero

        string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");
        string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");

        int size;
        double sigma;

        if (!int.TryParse(sizeEnv, out size) || size <= 0 || size % 2 == 0)
        {
            size = defaultSize;
        }

        if (!double.TryParse(sigmaEnv, out sigma) || sigma <= 0)
        {
            sigma = defaultSigma;
        }

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter to the entire image bounds
            var blurOptions = new GaussianBlurFilterOptions(size, sigma);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}