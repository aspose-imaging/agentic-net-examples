// HOW-TO: Sharpen a PNG Template with 5x5 Filter Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\template.png";
            string outputPath = @"C:\Images\template_sharpened.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage to apply filter
                RasterImage rasterImage = (RasterImage)pngImage;

                // Apply a 5x5 sharpen filter
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                pngImage.Save(outputPath);
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
 * 1. When you need to enhance the sharpness of a product label PNG before printing in a C# application.
 * 2. When generating thumbnails for a web gallery and want to apply a 5x5 sharpen filter to improve detail.
 * 3. When processing scanned documents stored as PNG files and require a quick edge‑enhancement step in .NET.
 * 4. When creating a batch job that loads a PNG template, sharpens it, and saves the result while ensuring resources are released.
 * 5. When integrating Aspose.Imaging into an image‑editing tool to let users apply a high‑intensity sharpen effect to PNG assets.
 */
