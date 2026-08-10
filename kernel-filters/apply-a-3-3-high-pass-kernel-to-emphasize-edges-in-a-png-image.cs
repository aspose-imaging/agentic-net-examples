// HOW-TO: Apply 3×3 High‑Pass Sharpen Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
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
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply a 3×3 high‑pass (sharpen) kernel
                raster.Filter(raster.Bounds, new SharpenFilterOptions(3, 1.0));

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
 * 1. When you need to enhance edges in a PNG before performing optical character recognition.
 * 2. When preparing product photos for a web catalog and want to sharpen details without changing the file format.
 * 3. When creating a preprocessing step for a computer‑vision algorithm that requires emphasized edges in input images.
 * 4. When automating batch processing of scanned documents to improve visual contrast for printing.
 * 5. When developing a C# desktop application that lets users apply a high‑pass filter to their PNG images on the fly.
 */
