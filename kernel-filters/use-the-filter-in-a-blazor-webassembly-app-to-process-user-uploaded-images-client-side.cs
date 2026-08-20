// HOW-TO: Sharpen PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image and apply a sharpen filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                raster.Save(outputPath);
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
 * 1. When a Blazor WebAssembly app needs to enhance the clarity of user‑uploaded PNG photos on the client side before displaying them.
 * 2. When an e‑commerce site wants to automatically sharpen product PNG images in the browser to improve visual appeal without server processing.
 * 3. When a C#‑based photo‑editing tool must apply a configurable sharpen filter to raster PNG files before saving.
 * 4. When a document management system requires client‑side preprocessing to reduce blur in scanned PNG documents prior to storage.
 * 5. When a progressive web app targeting mobile devices needs to quickly improve image sharpness in the browser using Aspose.Imaging without sending data to a backend.
 */
