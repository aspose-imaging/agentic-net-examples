using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
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
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Configure OTG rasterization to preserve transparency
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.Transparent // keep background transparent
                };

                // Assign rasterization options to the PNG options
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save the image as PNG
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
 * 1. When a developer needs to generate web‑ready PNG assets from vector OTG diagrams while preserving transparent backgrounds for overlay on HTML pages.
 * 2. When an e‑learning platform must convert instructor‑created OTG illustrations into PNG thumbnails that retain transparency for use in course catalogs.
 * 3. When a desktop publishing application imports OTG logos and saves them as PNG files with transparent backgrounds to embed in PDF reports.
 * 4. When a mobile app processes user‑uploaded OTG graphics and converts them to PNG for efficient rendering on iOS and Android devices without losing alpha channel data.
 * 5. When an automated build pipeline transforms OTG assets into PNG sprites while ensuring the background remains transparent for game UI integration.
 */