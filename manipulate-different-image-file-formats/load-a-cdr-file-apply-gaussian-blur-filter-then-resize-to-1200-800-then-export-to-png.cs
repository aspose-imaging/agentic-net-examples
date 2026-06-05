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
        string inputPath = "sample.cdr";
        string outputPath = "sample.png";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster operations
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image and cannot be processed.");
                    return;
                }

                // Apply Gaussian blur filter to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1200x800 using default resampling
                raster.Resize(1200, 800);

                // Save as PNG
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a web‑ready PNG thumbnail with a soft focus effect for an online portfolio.
 * 2. When an e‑commerce platform must automatically generate blurred preview images from CDR product designs before resizing them to 1200×800 for faster page loads.
 * 3. When a marketing automation script has to batch‑process CDR assets, apply a Gaussian blur to protect sensitive details, and output them as PNGs at a standard resolution for email campaigns.
 * 4. When a desktop publishing tool integrates Aspose.Imaging to allow users to import CDR files, apply a blur filter for background styling, and export the result as a 1200×800 PNG for print‑ready PDFs.
 * 5. When a content management system needs to render CDR logos with a subtle blur, resize them to 1200×800, and store them as PNG files for responsive web design.
 */