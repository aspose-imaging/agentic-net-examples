// HOW-TO: Apply Sharpen Filter to PNG and Save as JPEG Using DI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "output.jpg";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Simple DI container simulation
            var services = new Dictionary<string, Action<string, string>>();

            // Register Sharpen filter service
            services["SharpenFilter"] = (inPath, outPath) =>
            {
                // Load image
                using (Image image = Image.Load(inPath))
                {
                    // Cast to RasterImage
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter (kernel size 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save with JPEG options
                    rasterImage.Save(outPath, new JpegOptions());
                }
            };

            // Resolve and execute the filter service
            if (services.TryGetValue("SharpenFilter", out var sharpenService))
            {
                sharpenService(inputPath, outputPath);
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
 * 1. When you need to programmatically sharpen a PNG image and output a compressed JPEG in a .NET Core service that uses dependency injection.
 * 2. When building an image‑processing API that applies a custom filter before delivering JPEG thumbnails to web clients.
 * 3. When migrating a legacy batch script to C# and want to register filter operations in a DI container for easier testing and maintenance.
 * 4. When creating a photo‑editing tool that lets users enhance image sharpness on upload and store the result in a JPEG format.
 * 5. When integrating Aspose.Imaging into a microservice that processes user‑uploaded PNG files and saves optimized JPEGs with consistent filter settings.
 */
