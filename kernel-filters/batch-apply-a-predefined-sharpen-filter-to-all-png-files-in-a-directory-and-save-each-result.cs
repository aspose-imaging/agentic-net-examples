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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with suffix)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_sharpened.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Sharpen filter with default parameters (size=5, sigma=4.0)
                    var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                    rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

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
 * 1. When a developer needs to batch sharpen a collection of PNG assets for a web gallery using Aspose.Imaging for .NET in a C# application.
 * 2. When an e‑commerce platform must improve the visual clarity of product photos stored as PNG files before uploading them to a CDN, applying a Sharpen filter programmatically.
 * 3. When a desktop utility is required to automatically enhance scanned PNG documents by sharpening edges during nightly processing with C# and Aspose.Imaging.
 * 4. When a game studio wants to preprocess sprite sheets in PNG format, applying a consistent sharpening effect across all files to improve in‑game rendering.
 * 5. When a content management system needs to generate sharpened thumbnail versions of PNG images on the fly by iterating through a directory and saving the results with a suffix.
 */