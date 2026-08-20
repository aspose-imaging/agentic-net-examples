// HOW-TO: Render SVG to PNG with Custom Width and Height in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set custom rasterization dimensions (e.g., 800x600)
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.Size(800, 600) // custom width and height
                };

                // Prepare PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG image
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
 * 1. When you need to generate thumbnail PNGs of vector logos at a specific size for a web gallery.
 * 2. When an e‑commerce platform must convert product SVG illustrations to fixed‑dimension PNGs for email newsletters.
 * 3. When a reporting tool requires rasterizing scalable diagrams into PNG charts that fit a predefined layout.
 * 4. When a mobile app pre‑processes SVG icons into PNG assets with exact pixel dimensions for performance optimization.
 * 5. When an automated build pipeline creates PNG previews of SVG assets with consistent width and height for documentation.
 */
