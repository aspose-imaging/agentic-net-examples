// HOW-TO: Apply Motion Blur Followed by Sharpen Filter to PNG in C# (Aspose.Imaging for .NET)
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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply motion blur (length 2, smooth 1.0, angle 0 degrees)
                var motionOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply sharpen filter (kernel size 3, sigma 1.0)
                var sharpenOptions = new SharpenFilterOptions(3, 1.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

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
 * 1. When you need to reduce noise in a scanned PNG before OCR by first softening motion blur and then enhancing edges with a sharpen filter.
 * 2. When preparing product photos for an e‑commerce site, applying a subtle motion blur to smooth background artifacts and then sharpening details to make the item stand out.
 * 3. When creating visual effects for a game asset pipeline, you can programmatically add a slight motion blur and sharpen the result using Aspose.Imaging in C#.
 * 4. When automating batch processing of screenshots, you may want to apply a 2‑pixel motion blur to simulate motion and then sharpen to retain readability before saving.
 * 5. When integrating image preprocessing into a C# desktop application, this code demonstrates how to load a PNG, apply sequential filters, and save the enhanced image with Aspose.Imaging.
 */
