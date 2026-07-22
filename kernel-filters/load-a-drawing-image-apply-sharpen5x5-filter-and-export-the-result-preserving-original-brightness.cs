using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
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

            // Ensure output directory exists (creates current directory if none)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image (automatically determines format)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image; default options preserve original brightness
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
 * 1. When a developer needs to enhance the edge definition of a PNG drawing for a web‑based diagram editor while keeping the original brightness unchanged.
 * 2. When an automated batch process must sharpen scanned engineering schematics in BMP format before archiving them without altering their visual tone.
 * 3. When a C# application generates printable PDFs from vector drawings and requires a temporary raster PNG with a 5×5 sharpen filter to improve on‑screen clarity.
 * 4. When a mobile app syncs user‑created sketches to a server and applies a Sharpen5x5 filter to reduce blur caused by low‑resolution input devices while preserving the original lighting.
 * 5. When a CI/CD pipeline validates that image assets in a UI library meet sharpness standards by programmatically applying a 5×5 sharpen filter and saving the result with the same brightness for visual regression testing.
 */