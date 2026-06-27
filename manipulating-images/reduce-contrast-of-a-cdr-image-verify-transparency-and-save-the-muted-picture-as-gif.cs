using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_muted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the CDR image to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdrImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Verify transparency (check if background color has alpha < 255)
                        bool hasTransparency = raster.HasBackgroundColor && raster.BackgroundColor.A < 255;
                        Console.WriteLine($"Transparency detected: {hasTransparency}");

                        // Reduce contrast (negative value reduces contrast)
                        raster.AdjustContrast(-30f);

                        // Save the result as GIF
                        GifOptions gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
                    }
                }
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) vector file to a GIF with reduced contrast for web thumbnails while preserving any alpha transparency.
 * 2. When an automated image pipeline must verify that a CDR source contains transparent background before rasterizing it to a low‑contrast GIF for email newsletters.
 * 3. When a desktop application processes user‑uploaded CDR artwork, adjusts its visual intensity, and saves the result as a GIF for preview in a product catalog.
 * 4. When a batch job has to ensure the output directory exists, load a CDR file, mute its colors by decreasing contrast, and output a GIF that retains the original transparency for mobile apps.
 * 5. When troubleshooting image quality, a developer wants to programmatically check for background alpha values, apply a negative contrast adjustment, and export the muted image as a GIF for quick visual inspection.
 */