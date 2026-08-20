// HOW-TO: Apply Gaussian Blur to BigTIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\biginput.tif";
        string outputPath = @"C:\Images\blurred_output.png";

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

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG using default options
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to reduce noise in a large medical scan stored as BigTIFF before converting it to a web‑friendly PNG.
 * 2. When you want to create a softened preview of a high‑resolution satellite image saved as BigTIFF for quick display in a C# application.
 * 3. When a GIS workflow requires applying a Gaussian blur to a massive raster map and exporting the result as PNG for use in reports.
 * 4. When an archival system must process scanned documents in BigTIFF format, blur sensitive details, and store the output as PNG for secure sharing.
 * 5. When a desktop utility must batch‑process large photography files, apply a blur effect, and save them as PNG without custom compression settings.
 */
