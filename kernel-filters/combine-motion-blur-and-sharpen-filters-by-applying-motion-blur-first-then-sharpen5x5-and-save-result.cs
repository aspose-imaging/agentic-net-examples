using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply motion blur (using MotionWienerFilterOptions as a motion blur example)
                // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new MotionWienerFilterOptions(10, 1.0, 90.0));

                // Apply sharpen filter (5x5 kernel with sigma 4.0)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

                // Save the processed image
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
 * 1. When a developer needs to simulate camera movement on a PNG photograph and then restore edge detail for a product catalog, they can apply a motion blur followed by a Sharpen5x5 filter using Aspose.Imaging for .NET.
 * 2. When preparing frames for a motion‑blurred video thumbnail in a C# web service, the code can add a 10‑pixel vertical blur and sharpen the result to keep text readable.
 * 3. When cleaning up scanned documents that suffer from slight motion artifacts, a developer can load the image with Image.Load, apply MotionWienerFilterOptions and then SharpenFilterOptions to improve OCR accuracy.
 * 4. When generating stylized game sprites where a blur effect adds depth but the character outlines must stay crisp, the combined filters in a RasterImage ensure the PNG assets retain sharp edges.
 * 5. When automating batch processing of satellite imagery in a .NET console app, applying motion blur first and then a 5×5 sharpen kernel helps emphasize linear features while reducing noise.
 */