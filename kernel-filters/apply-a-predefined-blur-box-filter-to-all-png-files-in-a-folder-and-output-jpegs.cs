// HOW-TO: Apply Gaussian Blur to All PNGs and Save as JPEGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Process each PNG file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.png"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (used as a predefined blur box filter)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Prepare the output JPEG path
                    string outputFileName = Path.ChangeExtension(Path.GetFileName(inputPath), ".jpg");
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as JPEG
                    rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When you need to batch‑blur a collection of PNG screenshots before archiving them as smaller JPEG files.
 * 2. When you want to automatically obscure sensitive details in product photos stored as PNGs and deliver them as JPEGs for web publishing.
 * 3. When you are building a C# utility that converts high‑resolution PNG assets to compressed JPEGs while applying a Gaussian blur to reduce visual noise.
 * 4. When you must preprocess scanned PNG documents with a blur effect to improve OCR performance and then save the results in JPEG format.
 * 5. When you require a simple script to apply a predefined blur box filter to every PNG in a folder and output JPEGs for a mobile app’s image cache.
 */
