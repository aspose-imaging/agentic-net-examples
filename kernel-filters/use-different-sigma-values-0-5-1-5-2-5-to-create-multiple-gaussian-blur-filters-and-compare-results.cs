using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input image path
            string inputPath = "input.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory (created unconditionally)
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Parameters for Gaussian blur
            int radius = 5; // kernel size
            double[] sigmas = { 0.5, 1.5, 2.5 };

            foreach (double sigma in sigmas)
            {
                // Load the image as a raster image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Apply Gaussian blur with current sigma
                    raster.Filter(
                        raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(radius, sigma));

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"blur_sigma_{sigma}.png");

                    // Ensure output directory exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image
                    raster.Save(outputPath);
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
 * 1. When a developer needs to generate multiple PNG thumbnails with low, medium, and high Gaussian blur (sigma 0.5, 1.5, 2.5) to implement progressive image loading on a website.
 * 2. When a developer wants to compare the visual impact of different sigma values on a raster image to select the best blur strength for background defocus in a UI design.
 * 3. When a developer builds an automated test suite that validates Aspose.Imaging’s GaussianBlurFilterOptions across various sigma settings for quality assurance.
 * 4. When a developer preprocesses scanned PNG documents by applying gentle (sigma 0.5) to strong (sigma 2.5) blur to mask sensitive information before archiving.
 * 5. When a developer creates a batch‑processing tool that saves blurred PNG assets into an output folder for use in machine‑learning data‑augmentation pipelines.
 */