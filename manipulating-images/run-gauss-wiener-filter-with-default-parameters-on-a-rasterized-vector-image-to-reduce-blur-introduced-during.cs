// HOW-TO: Apply Gauss Wiener Filter to Rasterized Vector PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\vectorRasterized.png";
            string outputPath = @"C:\Images\vectorRasterized_GaussWiener.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the rasterized vector image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener filter with default parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions());

                // Save the filtered image
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
 * 1. When a developer converts a vector graphic to PNG and notices blur, they can use this code to sharpen the image with a Gauss‑Wiener filter.
 * 2. When preparing rasterized illustrations for print, the filter helps restore edge clarity after anti‑aliasing.
 * 3. When building an automated image‑processing pipeline that receives vector‑to‑raster conversions, the code ensures consistent visual quality across files.
 * 4. When optimizing UI assets generated from SVGs for mobile apps, the filter reduces softening caused by scaling.
 * 5. When performing batch cleanup of scanned PDFs that were exported as raster images, the filter can improve readability without manual editing.
 */
