// HOW-TO: Apply Gaussian Blur to JPEG Using Environment Variables in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");
            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");

            double sigma = 1.0;
            int size = 3;

            if (!string.IsNullOrEmpty(sigmaEnv) && double.TryParse(sigmaEnv, out double parsedSigma))
                sigma = parsedSigma;

            if (!string.IsNullOrEmpty(sizeEnv) && int.TryParse(sizeEnv, out int parsedSize))
                size = parsedSize;

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(size, sigma));
                raster.Save(outputPath, new JpegOptions());
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
 * 1. When you need to blur a JPEG image in an automated build pipeline and want the blur radius and strength to be configurable without changing code.
 * 2. When a web service processes user‑uploaded photos and must apply a Gaussian blur whose sigma and kernel size are set via environment variables for each deployment.
 * 3. When you are creating a batch image‑processing script that uses Aspose.Imaging to apply consistent blur effects across many files while allowing runtime adjustments through CI/CD variables.
 * 4. When you want to integrate image privacy protection into a C# application and need to tweak the blur intensity per environment (development, staging, production) without recompiling.
 * 5. When you are building a containerized microservice that applies a Gaussian blur to incoming JPEGs and requires the blur parameters to be supplied as container environment settings.
 */
