using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Retrieve configuration from environment variables
                string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");
                string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");

                // Default values
                int size = 5;
                double sigma = 4.0;

                // Parse environment variables if they are valid
                if (int.TryParse(sizeEnv, out int parsedSize) && parsedSize > 0)
                {
                    size = parsedSize;
                }

                if (double.TryParse(sigmaEnv, out double parsedSigma) && parsedSigma > 0)
                {
                    sigma = parsedSigma;
                }

                // Apply Gaussian blur filter with configured parameters
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(size, sigma);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a CI/CD pipeline needs to apply a configurable Gaussian blur to PNG assets before publishing, developers can set GAUSSIAN_SIGMA and GAUSSIAN_SIZE as environment variables to adjust the effect without changing code.
 * 2. When a desktop application processes user‑uploaded images and must allow administrators to change blur strength on the fly, using environment variables lets them modify size and sigma without recompiling.
 * 3. When a batch job runs nightly to anonymize faces in JPEG files by blurring them, the script can read GAUSSIAN_SIGMA and GAUSSIAN_SIZE from the server’s environment to meet different privacy regulations.
 * 4. When a cloud‑based microservice receives image URLs and needs to standardize visual quality across varied devices, developers can configure the Gaussian blur parameters via environment variables for each deployment region.
 * 5. When a test suite validates image‑processing algorithms and wants to experiment with different blur intensities, setting GAUSSIAN_SIGMA and GAUSSIAN_SIZE in the test environment provides quick, repeatable configuration.
 */