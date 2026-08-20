// HOW-TO: Apply Sharpen Filter to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image
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
 * 1. When you need to enhance the details of product photos in a PNG catalog before uploading them to an e‑commerce site.
 * 2. When you want to automatically sharpen scanned screenshots stored as PNG files during a batch image‑processing pipeline in a C# application.
 * 3. When you are building a desktop tool that improves the clarity of PNG graphics for print‑ready PDFs using Aspose.Imaging.
 * 4. When you must programmatically increase the edge contrast of PNG icons for a UI theme without using external image editors.
 * 5. When you are developing a server‑side service that receives PNG uploads and applies a convolution‑based sharpen filter before saving them to storage.
 */
