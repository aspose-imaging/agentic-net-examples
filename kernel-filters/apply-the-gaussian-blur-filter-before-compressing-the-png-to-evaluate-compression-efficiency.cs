// HOW-TO: Apply Gaussian Blur and High Compression to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size = 5, sigma = 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PNG save options with high compression
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    FilterType = PngFilterType.Adaptive,
                    Progressive = true
                };

                // Save the processed image as PNG
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
 * 1. When you need to reduce the file size of screenshots while smoothing noise before uploading to a web server.
 * 2. When preparing product photos for an e‑commerce catalog that require both a soft blur effect and maximum PNG compression to meet bandwidth limits.
 * 3. When generating thumbnail previews for a mobile app where applying a Gaussian blur improves visual consistency and high compression saves storage space.
 * 4. When automating a batch process that optimizes scanned documents by blurring artifacts and saving them as progressive PNGs with the smallest possible size.
 * 5. When implementing a server‑side image pipeline that must apply a blur filter for privacy masking and then compress the PNG for secure archival.
 */
