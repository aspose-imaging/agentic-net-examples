using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string tempPngPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\result.png";

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

            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Export the first page (or whole image) to a temporary PNG
                cdrImage.Save(tempPngPath);
            }

            // Load the temporary PNG as a raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
            {
                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the entire image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1200x800 using the default resampling method
                rasterImage.Resize(1200, 800);

                // Save the final image as PNG
                rasterImage.Save(outputPath);
            }

            // Optionally delete the temporary PNG
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) design into a web‑ready PNG thumbnail with a soft blur effect and a fixed 1200×800 size for an online portfolio.
 * 2. When an e‑commerce platform must automatically generate blurred preview images from supplier‑provided CDR files before displaying them at a standard resolution on product pages.
 * 3. When a marketing automation script has to batch‑process CDR artwork, apply a Gaussian blur to hide sensitive details, resize it, and store the result as PNG for email campaigns.
 * 4. When a content management system imports legacy CDR graphics, applies a blur filter for visual consistency, resizes them to fit a responsive layout, and saves them as PNG for browser delivery.
 * 5. When a desktop application needs to read a CDR file, create a temporary raster PNG, apply a Gaussian blur, resize to 1200×800, and output the final PNG for printing or digital signage.
 */