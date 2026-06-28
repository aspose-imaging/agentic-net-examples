using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.svg";
            string outputPath = "output/rasterized.png";

            // Validate input file existence
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
                // Configure SVG rasterization options with page size in inches
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Example: 5 inches width, 3 inches height
                    PageSize = new SizeF(5.0f, 3.0f)
                };

                // Set up PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image
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
 * 1. When a developer needs to generate print‑ready PNG thumbnails from SVG logos at a specific physical size (e.g., 5 in × 3 in) for marketing materials, they can use SvgRasterizationOptions.PageSize in Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must convert product SVG diagrams into PNG images that fit exactly onto a 4‑inch‑wide label, specifying the page size in inches ensures consistent dimensions across all items.
 * 3. When a reporting tool creates PDF reports that embed rasterized SVG charts, setting the page size in inches with SvgRasterizationOptions guarantees the charts occupy the intended space on the page.
 * 4. When a mobile app needs to display SVG icons as PNG assets at a precise physical size for high‑resolution screens, developers can control the output dimensions by configuring PageSize in inches.
 * 5. When an automated build pipeline processes SVG assets into PNG assets for a desktop publishing workflow, using Aspose.Imaging’s SvgRasterizationOptions with a defined page size in inches standardizes the output for downstream layout software.
 */