// HOW-TO: Apply Motion Wiener Filter to Multiple PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole processing in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of PNG files to process (add or remove file names as needed)
            string[] files = new string[]
            {
                "image1.png",
                "image2.png",
                "image3.png"
            };

            // Parameters for the Motion Wiener filter
            int size = 10;          // Gaussian kernel size (must be odd)
            double sigma = 1.0;    // Smoothing factor
            double angle = 90.0;   // Angle in degrees

            foreach (string fileName in files)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".MotionWiener.png");

                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists (creates it if necessary)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply the filter, and save the result
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access the Filter method
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Motion Wiener filter to the whole image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new MotionWienerFilterOptions(size, sigma, angle));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to clean up motion blur in a series of low‑light PNG photos captured by a security camera.
 * 2. When you want to automatically process dozens of PNG snapshots from a night‑time microscopy experiment to improve clarity.
 * 3. When you must integrate a batch image‑enhancement step into a C# workflow that prepares PNG assets for a mobile app.
 * 4. When you are building a server‑side service that receives PNG uploads from users and must reduce motion artifacts before storage.
 * 5. When you require a repeatable script to apply the same motion‑Wiener parameters to multiple PNG files during automated testing of image‑processing pipelines.
 */
