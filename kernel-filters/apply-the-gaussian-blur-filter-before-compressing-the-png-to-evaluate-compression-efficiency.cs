using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.png";
            string outputPath = "C:\\temp\\sample_blur_compressed.png";

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
                // Cast to RasterImage to use filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (size = 5, sigma = 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Configure PNG compression options
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9,                         // Max compression
                    FilterType = PngFilterType.Adaptive,          // Adaptive filter for better compression
                    Progressive = true                            // Enable progressive loading
                };

                // Save the processed image with compression
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to reduce the file size of PNG assets for a web application while preserving visual quality by applying a Gaussian blur before compression.
 * 2. When preparing product catalog images for an e‑commerce site and wants to smooth details to improve PNG compression efficiency using Aspose.Imaging in C#.
 * 3. When generating thumbnails for a mobile app and wants to pre‑process the PNG with a Gaussian blur to achieve higher compression levels without noticeable loss.
 * 4. When archiving scanned documents as PNG files and applying a blur filter to minimize noise before saving with maximum compression and progressive loading.
 * 5. When optimizing PNG graphics for email newsletters and need to programmatically apply a Gaussian blur filter and configure PNGOptions for maximum compression in a .NET environment.
 */