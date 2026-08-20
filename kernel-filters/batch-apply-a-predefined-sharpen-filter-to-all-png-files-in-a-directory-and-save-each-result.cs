// HOW-TO: Batch Sharpen All PNG Images in a Folder Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".sharpened.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Sharpen filter with kernel size 5 and sigma 4.0
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image as PNG
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
 * 1. When you need to improve the clarity of dozens of product photos stored as PNGs before uploading them to an e‑commerce site.
 * 2. When an automated workflow must enhance scanned screenshots by applying a sharpen filter to every PNG in a nightly batch.
 * 3. When a desktop application processes user‑generated PNG graphics and must save a sharpened version alongside the original.
 * 4. When a server‑side service prepares PNG assets for a mobile game, applying a consistent sharpening effect to all images in a directory.
 * 5. When a migration script updates legacy PNG files by batch‑sharpening them to meet new visual quality standards.
 */
