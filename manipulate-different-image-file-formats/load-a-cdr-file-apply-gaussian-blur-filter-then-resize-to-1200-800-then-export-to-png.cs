using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster operations
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply Gaussian blur filter to the entire image
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
 * 1. When a developer needs to convert CorelDRAW (CDR) artwork into a web‑ready PNG thumbnail with a soft focus effect, they can load the CDR, apply a Gaussian blur, resize to 1200×800, and save using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must generate blurred background images from vendor‑provided CDR files for product detail pages, this C# code loads the vector file, blurs it, resizes it, and exports a PNG for fast browser rendering.
 * 3. When a marketing automation script has to batch‑process CDR logos into uniformly sized PNG assets with a subtle blur for use in email newsletters, the code demonstrates the required image loading, filtering, resizing, and saving steps.
 * 4. When a desktop publishing tool needs to preview CorelDRAW designs as low‑resolution PNG previews with a Gaussian blur to protect intellectual property, the example shows how to perform the conversion in C#.
 * 5. When a content management system must ingest client‑supplied CDR files, apply a blur for privacy compliance, resize them to 1200×800 for consistency, and store them as PNG files, this Aspose.Imaging workflow provides the solution.
 */