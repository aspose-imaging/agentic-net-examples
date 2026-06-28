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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with progressive (interlaced) encoding
                var pngOptions = new PngOptions
                {
                    Progressive = true
                };

                // Set rasterization options for OTG conversion
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save as PNG with the specified options
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
 * 1. When a web application needs to display vector‑based OTG graphics as progressive PNG images for faster page load on slow connections.
 * 2. When an e‑learning platform converts OTG diagrams into interlaced PNGs to allow students to see a low‑resolution preview while the full image loads.
 * 3. When a desktop publishing tool automates batch conversion of OTG assets to PNG with progressive rendering for inclusion in print‑ready PDFs.
 * 4. When a mobile app processes user‑uploaded OTG files and saves them as interlaced PNGs to reduce memory usage during incremental rendering.
 * 5. When a cloud‑based image service provides on‑the‑fly conversion of OTG icons to PNG with interlacing to support responsive UI elements.
 */