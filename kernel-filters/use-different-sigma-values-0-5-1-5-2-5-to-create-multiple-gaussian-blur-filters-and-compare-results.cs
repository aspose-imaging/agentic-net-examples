// HOW-TO: Apply Multiple Gaussian Blur Filters with Different Sigma Values in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image path
            string inputPath = @"c:\temp\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define sigma values to test
            double[] sigmaValues = { 0.5, 1.5, 2.5 };
            // Fixed kernel size (must be positive odd integer)
            int kernelSize = 5;

            // Load the source image once
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Filter method
                RasterImage rasterImage = (RasterImage)image;

                foreach (double sigma in sigmaValues)
                {
                    // Create Gaussian blur filter options with current sigma
                    var blurOptions = new GaussianBlurFilterOptions(kernelSize, sigma);

                    // Apply the filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Prepare output path for this sigma
                    string outputPath = $@"c:\temp\sample.GaussianBlur_{sigma}.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
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
 * 1. When you need to generate several versions of a PNG image with varying blur strengths to evaluate visual impact for UI design.
 * 2. When you want to programmatically compare the effect of different sigma values on a raster image using Aspose.Imaging in a .NET application.
 * 3. When you must batch‑process a single source image and save separate files for each Gaussian blur level for quality‑control testing.
 * 4. When you are building an automated test that verifies that the GaussianBlurFilterOptions correctly respects the kernel size and sigma parameters.
 * 5. When you need to create side‑by‑side blurred images for documentation or a presentation that demonstrates how sigma influences the smoothness of edges.
 */
