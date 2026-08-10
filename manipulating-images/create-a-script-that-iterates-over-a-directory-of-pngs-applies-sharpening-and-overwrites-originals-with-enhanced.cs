// HOW-TO: Batch Sharpen PNG Images and Overwrite Originals in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded directories
            string inputDirectory = "InputPngs";
            string outputDirectory = "InputPngs";

            // Ensure input directory exists
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

            // Get all PNG files
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path (overwrite original)
                string outputPath = inputPath;

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, apply sharpen filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
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
 * 1. When you need to improve the visual clarity of a large set of product photos stored as PNGs before publishing them on an e‑commerce site.
 * 2. When an automated build process must apply a sharpening filter to all PNG assets in a folder and replace the originals to keep the repository size unchanged.
 * 3. When a desktop application has to batch‑process user‑uploaded PNG screenshots, enhancing details without creating duplicate files.
 * 4. When a migration script must prepare PNG graphics for print by sharpening them in place using Aspose.Imaging in a C# environment.
 * 5. When a maintenance routine has to iterate through a directory of PNG icons, apply a consistent sharpening strength, and save the updated images over the existing files.
 */
