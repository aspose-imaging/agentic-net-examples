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
        string outputPath = @"C:\Images\blurred.png";

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

                // Save the result as PNG with default options
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
 * 1. When a developer needs to convert a high‑resolution BigTIFF satellite image into a smaller PNG for web preview while softening details with a Gaussian blur.
 * 2. When an imaging pipeline must preprocess large medical scans in BigTIFF format by applying a blur filter to reduce noise before archiving them as PNG files.
 * 3. When a GIS application requires loading massive GeoTIFF maps, applying a blur effect for visual smoothing, and exporting the result as a PNG for inclusion in reports.
 * 4. When a digital asset management system needs to generate blurred thumbnail PNGs from BigTIFF source files to protect sensitive content while still showing a preview.
 * 5. When a batch‑processing tool automates the conversion of BigTIFF photographs to PNG format with a default Gaussian blur to create consistent, web‑friendly images.
 */