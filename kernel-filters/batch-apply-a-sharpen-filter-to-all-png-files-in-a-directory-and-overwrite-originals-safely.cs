// HOW-TO: Batch Sharpen All PNG Images in a Folder Using C# Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing PNG files
        string inputDirectory = @"C:\Images";

        try
        {
            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path is the same as input path (overwrite)
                string outputPath = inputPath;

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter with default kernel size and sigma
                    var sharpenOptions = new SharpenFilterOptions(); // default constructor
                    rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                    // Save back to the original file (overwrite)
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
 * 1. When you need to improve the visual clarity of a large collection of PNG photos before publishing them on a website, you can batch‑sharpen each file in place with Aspose.Imaging in C#.
 * 2. When an automated build process must enhance product screenshots stored as PNGs without creating duplicate files, this code applies a sharpen filter to every image and overwrites the originals safely.
 * 3. When a desktop application must prepare user‑uploaded PNG graphics for printing by increasing edge definition across an entire folder, the routine iterates through the directory and sharpens each image in one pass.
 * 4. When a migration script has to standardize image quality for a legacy PNG archive, you can use the filter to batch process the files while preserving their original filenames and paths.
 * 5. When a CI/CD pipeline needs to ensure that all PNG assets in a repository meet a minimum sharpness level before deployment, the code filters each image and saves the result back to the source location.
 */
