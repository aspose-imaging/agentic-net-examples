// HOW-TO: Resize SVG to 300x300 PNG Using Lanczos in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 300x300 using Lanczos resampling
                var resizeSettings = new ImageResizeSettings
                {
                    Mode = ResizeType.LanczosResample
                };
                image.Resize(300, 300, resizeSettings);

                // Set up PNG save options with rasterization settings
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Define the page size to match the target dimensions
                    PageSize = new Size(300, 300)
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized PNG
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
 * 1. When you need to generate a fixed-size PNG thumbnail from a scalable SVG for a web gallery.
 * 2. When an e‑commerce platform requires product icons resized to 300x300 pixels with high-quality Lanczos resampling.
 * 3. When converting vector logos into raster PNGs for email signatures while preserving sharpness.
 * 4. When preparing SVG assets for mobile apps that only accept PNG images of a specific dimension.
 * 5. When automating batch processing of SVG files to create uniformly sized PNGs for PDF reports.
 */
