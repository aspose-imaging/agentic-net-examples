// HOW-TO: Remove Background from SVG and Save as PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\sample.png";

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

            // Load SVG image
            using (var svgImage = new SvgImage(inputPath))
            {
                // Remove background using default analysis
                svgImage.RemoveBackground();

                // Configure rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When you need to clean up a logo SVG by removing its background before embedding it in a web page as a PNG.
 * 2. When you want to convert vector icons from SVG to PNG for use in a mobile app while ensuring the background is transparent.
 * 3. When you are preparing product illustrations for an e‑commerce catalog and must strip the SVG background before rasterizing to PNG.
 * 4. When you need to generate transparent PNG thumbnails from SVG drawings for a content management system.
 * 5. When you automate batch processing of SVG assets to create PNG assets with no background for a UI design workflow.
 */
