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
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization to preserve transparency
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.Transparent
                };

                // Set PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When a developer needs to embed legacy WMF vector graphics into a modern web page that only supports PNG with transparent backgrounds.
 * 2. When an automated report generator must convert WMF logos into PNG thumbnails while keeping the transparent background for seamless overlay.
 * 3. When a desktop application imports user‑supplied WMF icons and saves them as PNG files for use in high‑DPI UI elements that require alpha channel support.
 * 4. When a batch processing script migrates a library of WMF assets to PNG format for compatibility with mobile apps that cannot render WMF but need transparent images.
 * 5. When a C# service creates PNG previews of WMF diagrams for email attachments, ensuring the background stays transparent to match the email template.
 */