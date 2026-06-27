using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\blurred.png";
        string outputPath = @"C:\temp\restored.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter to reduce motion blur
                // Parameters: size = 10, sigma = 1.0, angle = 90 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                // Apply Sharpen filter for edge definition
                // Parameters: radius = 5, sigma = 4.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a developer needs to restore a PNG photo taken from a moving vehicle that appears blurred due to motion, they can use the Motion‑Wiener filter followed by a Sharpen filter in C# with Aspose.Imaging to reduce blur and enhance edges.
 * 2. When an e‑commerce platform receives product PNG images captured with a handheld camera that suffer from camera shake, the code can automatically deblur and sharpen the images before publishing them online.
 * 3. When a medical imaging application processes PNG scans that were taken during patient movement, applying the Motion‑Wiener filter and then sharpening ensures clearer diagnostic visuals.
 * 4. When a digital archivist digitizes historical PNG documents scanned with a moving scanner, the filter sequence can correct motion blur and improve text legibility.
 * 5. When a game developer imports PNG textures that appear soft due to motion blur in the source artwork, the code can clean up the textures by deblurring and sharpening them for sharper in‑game rendering.
 */