using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                var rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 1.5
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 1.5)
                );

                // Save the result as PNG
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to soften the edges of a scanned BMP document before converting it to a web‑friendly PNG for online viewing.
 * 2. When an application must preprocess legacy BMP graphics by applying a Gaussian blur with sigma 1.5 to reduce noise prior to saving as PNG for a mobile app.
 * 3. When a batch job converts high‑resolution BMP screenshots into PNG thumbnails while applying a Gaussian blur filter to create a subtle background effect.
 * 4. When a photo‑editing tool built with C# uses Aspose.Imaging to blur a BMP portrait and export the result as PNG for further composition.
 * 5. When a server‑side service receives BMP uploads, applies a Gaussian blur to meet a design guideline, and stores the processed image as PNG for CDN distribution.
 */