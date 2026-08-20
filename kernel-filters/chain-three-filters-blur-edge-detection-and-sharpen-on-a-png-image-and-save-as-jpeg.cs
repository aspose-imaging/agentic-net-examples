// HOW-TO: Chain Blur, Edge Detection, and Sharpen Filters on PNG to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output.jpg";

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
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply a sharpen filter as a simple edge‑detection step
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Apply another sharpen filter for final sharpening
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as JPEG
                rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When you need to reduce noise in a PNG, highlight edges, and enhance details before converting it to a JPEG for web publishing.
 * 2. When preparing product photos for an e‑commerce site, applying blur, edge detection, and sharpening can improve visual clarity while reducing file size by saving as JPEG.
 * 3. When creating thumbnails that require a smooth background, defined outlines, and crisp final appearance, chaining these filters automates the process in C#.
 * 4. When migrating legacy PNG assets to JPEG format and want to apply a consistent image‑processing pipeline to maintain quality across the batch.
 * 5. When building an automated image‑processing service that must preprocess PNG uploads with blur, edge detection, and sharpening before storing them as JPEGs.
 */
