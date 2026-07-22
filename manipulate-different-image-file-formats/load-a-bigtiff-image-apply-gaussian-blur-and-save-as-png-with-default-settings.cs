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

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to use filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image as PNG with default settings
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
 * 1. When a developer needs to convert a high‑resolution BigTIFF satellite image to a smaller PNG for web preview while softening details with a Gaussian blur.
 * 2. When a medical imaging application must load a large pathology slide in BigTIFF, apply a blur to reduce noise, and export the result as a PNG for reporting.
 * 3. When an archival system processes massive scanned documents stored as BigTIFF, applies a uniform blur to mask sensitive information, and saves the sanitized version as PNG.
 * 4. When a GIS tool requires loading a BigTIFF elevation map, smoothing the terrain data with a Gaussian blur, and generating a PNG thumbnail for a user interface.
 * 5. When a batch‑processing script needs to read a BigTIFF photograph, apply a radius‑5 Gaussian blur for artistic effect, and output a PNG file with default compression settings.
 */