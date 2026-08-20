// HOW-TO: Apply Motion Blur Followed By Sharpen Filter To PNG In C# (Aspose.Imaging for .NET)
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

                // Apply motion blur (using Gaussian blur as a stand‑in for motion blur)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // Apply sharpen filter (5x5 kernel)
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
 * 1. When you need to reduce motion artifacts in a PNG photo and then sharpen its edges before publishing it on a website using Aspose.Imaging for .NET in C#.
 * 2. When creating a game asset where a motion‑blur effect adds a sense of speed and a subsequent sharpen filter preserves important details, all processed programmatically in C#.
 * 3. When generating video thumbnails that require a subtle blur to suggest movement followed by sharpening to keep the title text readable, using Aspose.Imaging filters.
 * 4. When batch‑processing e‑commerce product images to apply a light motion blur for background smoothing and then a 5×5 sharpen to highlight the product, saving the results as PNG files.
 * 5. When building an image‑conversion pipeline in a C# application that must apply a custom filter chain—motion blur first, then sharpen—before saving the output in a different format.
 */
