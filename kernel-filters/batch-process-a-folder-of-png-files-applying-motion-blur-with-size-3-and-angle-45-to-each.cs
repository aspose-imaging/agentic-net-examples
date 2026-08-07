using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, process, and save the image
                using (Image image = Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                    // Apply motion blur with size 3, smooth factor 1.0, angle 45 degrees
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 45.0));

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
 * 1. When a developer needs to automatically add a subtle motion‑blur effect to a batch of product PNG images before publishing them on an e‑commerce website.
 * 2. When a game‑development pipeline must process multiple sprite PNG files to simulate motion by applying a 45‑degree blur with size 3 using C# and Aspose.Imaging.
 * 3. When a marketing team wants to generate a series of promotional PNG banners with a consistent motion‑blur style for social‑media ads via a .NET batch script.
 * 4. When an archival system requires preprocessing scanned PNG photographs by adding a uniform motion blur to reduce visual noise before long‑term storage.
 * 5. When a developer creates a desktop utility that scans a folder of PNG icons and applies a 45‑degree motion blur to produce a stylized “loading” effect for UI themes.
 */