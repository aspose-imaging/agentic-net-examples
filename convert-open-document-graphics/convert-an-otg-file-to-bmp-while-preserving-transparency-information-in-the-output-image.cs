using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG to preserve vector data
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set BMP options (default compression supports transparency)
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save as BMP preserving transparency
                image.Save(outputPath, bmpOptions);
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
 * 1. When a .NET application must import legacy OTG vector graphics and export them as BMP files for compatibility with Windows desktop software while keeping transparent backgrounds.
 * 2. When an image processing pipeline needs to batch‑convert OTG design assets into BMP format for use in a game engine that only supports raster images with alpha channels.
 * 3. When a reporting tool generates charts in OTG format and the final PDF requires embedded BMP images with preserved transparency for proper layering.
 * 4. When a document conversion service receives OTG files from clients and must deliver BMP thumbnails that retain the original transparent regions for preview in web galleries.
 * 5. When a migration script updates an old CAD system’s assets by rasterizing OTG drawings into BMP files so that legacy Windows applications can display them without losing the transparent background.
 */