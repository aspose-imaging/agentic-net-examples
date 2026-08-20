// HOW-TO: Convert WMF to PNG with Transparent Background and Alpha Channel in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
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
                // Configure rasterization options with a transparent background
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.Transparent
                };

                // Set PNG options and attach the rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG preserving the alpha channel
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
 * 1. When you need to display legacy WMF icons on a modern web page that requires PNG images with transparent backgrounds.
 * 2. When generating PDF reports that embed vector graphics converted to PNG while preserving alpha for overlay effects in a C# application.
 * 3. When creating thumbnails of WMF drawings for a gallery where the background must remain invisible to blend with different UI themes.
 * 4. When automating a batch conversion of corporate WMF logos to PNG assets for use in mobile apps that need proper transparency.
 * 5. When processing user‑uploaded WMF files in a .NET service and saving them as PNGs so they can be composited over other images without a solid background.
 */
