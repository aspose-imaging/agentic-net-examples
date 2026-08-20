// HOW-TO: Apply Gaussian Blur to PNG Without Color Shift in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to gain access to filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur without altering color channels (IgnoreAlpha left false)
                // Size = 5 (kernel size), Sigma = 4.0 (blur intensity)
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image preserving its original color information
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to soften a product photo in a PNG file while keeping its original colors intact for an e‑commerce website.
 * 2. When preparing UI assets where a subtle blur is required but any color shift would break the design palette.
 * 3. When processing scanned documents saved as PNG and you want to reduce noise without altering the document’s true colors.
 * 4. When creating a blurred background effect for a game sprite stored in PNG format and you must preserve the sprite’s exact hues.
 * 5. When automating batch image enhancements in a C# application and you need to apply Gaussian blur without affecting the PNG’s color fidelity.
 */
