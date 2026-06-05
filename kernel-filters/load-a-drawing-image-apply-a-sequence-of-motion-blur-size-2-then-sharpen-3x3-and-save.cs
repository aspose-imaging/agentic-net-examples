using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
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
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur (using MotionWienerFilterOptions as the closest match)
                // Length = 2, smooth = 1.0 (default), angle = 0 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(2, 1.0, 0.0));

                // Apply a sharpen filter with a 3x3 kernel (size = 3) and sigma = 1.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

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
 * 1. When a developer needs to clean up a scanned technical drawing in PNG format by reducing motion artifacts and enhancing edge details before archiving it.
 * 2. When an engineering web service must automatically process uploaded blueprint images, applying a subtle motion blur of size 2 followed by a 3×3 sharpen filter using Aspose.Imaging for .NET to improve visual clarity.
 * 3. When a desktop C# application prepares illustration assets for print by loading a PNG, smoothing slight camera shake with a MotionWiener filter and then sharpening fine lines to meet publishing standards.
 * 4. When a batch job processes a folder of CAD screenshots, using RasterImage.Filter to apply motion blur and sharpen filters sequentially to ensure consistent image quality across all files.
 * 5. When a document management system stores annotated drawings and wants to programmatically enhance them on upload by applying motion blur (length 2) and a 3×3 sharpen filter before saving the result as a PNG.
 */