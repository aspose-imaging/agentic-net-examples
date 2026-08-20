// HOW-TO: Apply Gaussian Blur to PNG Asynchronously in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.GaussianBlur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform the image processing on a background thread
            await Task.Run(() =>
            {
                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Configure Gaussian blur filter (size = 5, sigma = 4.0)
                    var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                    // Apply the filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating a desktop photo‑editing tool that lets users apply a blur effect without freezing the UI, you can use this async Gaussian blur code on PNG files.
 * 2. When generating blurred preview thumbnails for a gallery website, the background processing ensures the main thread stays responsive.
 * 3. When building a WPF or WinForms application that needs to blur user‑uploaded PNG images before saving them to disk, async filtering prevents UI lag.
 * 4. When implementing a batch‑image pipeline that applies a Gaussian blur to PNG assets on a background thread, this approach keeps the application responsive.
 * 5. When preparing PNG images for privacy‑preserving overlays (e.g., blurring faces) in a real‑time C# app, the asynchronous filter lets other tasks continue uninterrupted.
 */
