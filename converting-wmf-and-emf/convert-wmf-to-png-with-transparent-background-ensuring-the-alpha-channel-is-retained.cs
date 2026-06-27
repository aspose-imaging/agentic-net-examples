using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.png";

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
                // Configure rasterization to produce a PNG with transparent background
                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.Transparent
                };

                // Set PNG options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as PNG, preserving alpha channel
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
 * 1. When a Windows desktop application needs to display legacy WMF icons on a modern UI that requires PNG images with transparent backgrounds, a developer can use this code to convert the WMF files while preserving the alpha channel.
 * 2. When generating PDF reports that embed vector graphics originally stored as WMF, but the final document format requires raster PNG images with transparency, this snippet enables the conversion in C# using Aspose.Imaging.
 * 3. When automating a batch process that extracts vector logos from old design assets (WMF) and prepares them for web use as PNGs with transparent backgrounds, the code provides a reliable way to retain the alpha channel.
 * 4. When a game development pipeline imports WMF sprites and needs them as PNG textures with per‑pixel transparency for rendering, this example shows how to rasterize and save them correctly in .NET.
 * 5. When a content management system uploads user‑supplied WMF diagrams and must store them as PNG thumbnails with transparent backgrounds for responsive web pages, the code demonstrates the necessary conversion steps.
 */