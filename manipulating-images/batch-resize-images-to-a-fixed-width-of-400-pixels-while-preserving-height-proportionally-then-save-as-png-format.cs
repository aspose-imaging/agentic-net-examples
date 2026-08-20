// HOW-TO: Batch Resize Images To 400px Width And Convert To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, and save the image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize width to 400 pixels, preserving aspect ratio
                    image.ResizeWidthProportionally(400, ResizeType.NearestNeighbourResample);

                    // Save as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate web‑ready thumbnails for a large collection of photos by scaling each image to a fixed 400‑pixel width while keeping the original height proportionally.
 * 2. When you must convert a mixed set of source formats (JPEG, BMP, TIFF) into PNG files for consistent transparency support across a website.
 * 3. When an automated build or deployment script has to process all images in a folder, resize them, and store the results in a separate output directory without manual intervention.
 * 4. When you are preparing product images for an e‑commerce platform that requires a uniform width but allows variable heights to preserve aspect ratios.
 * 5. When you want to use Aspose.Imaging in a C# application to batch‑process images, applying nearest‑neighbour resampling for fast resizing before saving them as PNGs.
 */
