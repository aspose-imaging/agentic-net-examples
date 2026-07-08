using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Configure vector rasterization options for CDR to preserve transparency
                var rasterOptions = new CdrRasterizationOptions
                {
                    // Transparent background ensures alpha channel is kept
                    BackgroundColor = Color.Transparent
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PNG preserving alpha channel
                image.Save(outputPath, pngOptions);
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
 * 1. When a graphic design workflow requires converting CorelDRAW (.cdr) files to web‑ready PNG images while keeping transparent backgrounds for overlay on websites.
 * 2. When an e‑commerce platform needs to generate product thumbnails from CDR source files without losing the alpha channel so the images blend seamlessly with different page themes.
 * 3. When a desktop publishing application automates batch conversion of vector CDR assets to PNG for inclusion in PDF reports, preserving transparency for accurate layering.
 * 4. When a mobile app processes user‑uploaded CDR logos and converts them to PNG icons that retain their transparent background for use in UI elements.
 * 5. When a digital asset management system imports legacy CDR artwork and stores it as PNG files with preserved alpha channels to support downstream image editing and compositing.
 */