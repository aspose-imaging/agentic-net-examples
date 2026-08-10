// HOW-TO: Measure Memory Usage of 7x7 Gaussian Blur on High Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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

            // Record memory usage before processing
            long memoryBefore = GC.GetTotalMemory(true);

            // Load the high‑resolution PNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Configure a 7x7 Gaussian blur filter
                var blurOptions = new GaussianBlurFilterOptions(3, 1.0); // radius 3 (approx. 7x7), sigma 1.0
                blurOptions.Size = 7; // explicit kernel size

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, blurOptions);

                // Prepare PNG save options
                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the filtered image
                raster.Save(outputPath, saveOptions);
            }

            // Record memory usage after processing
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory used: {memoryAfter - memoryBefore} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure that applying a large Gaussian blur to a high‑resolution PNG does not exceed the memory limits of your .NET application.
 * 2. When you want to profile the RAM impact of image filtering before deploying a batch‑processing service that handles high‑resolution photos.
 * 3. When you are optimizing a server‑side image pipeline and need concrete memory numbers for a 7×7 kernel blur operation.
 * 4. When you compare different blur kernel sizes or filter libraries and require a baseline memory consumption measurement for PNG files.
 * 5. When you troubleshoot out‑of‑memory exceptions in a C# program that processes large PNG images with Gaussian filters.
 */
