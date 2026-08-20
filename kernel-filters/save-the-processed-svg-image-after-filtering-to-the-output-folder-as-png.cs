// HOW-TO: Convert SVG to PNG and Save to Output Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for rasterization options
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid SVG image.");
                    return;
                }

                // Define PNG export options
                var pngOptions = new PngOptions
                {
                    // Optional: set size or other rasterization settings here
                    // For example, set a default size if needed
                    // Width = 800,
                    // Height = 600
                };

                // Save the rasterized image as PNG
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
 * 1. When you need to generate raster PNG thumbnails from vector SVG assets for web display.
 * 2. When an automated build process must convert design SVG files into PNGs for inclusion in a mobile app.
 * 3. When a server‑side service receives SVG logos and must store them as PNGs for email signatures.
 * 4. When you want to batch‑process SVG diagrams and save them as PNG images in a specific output directory.
 * 5. When a reporting tool requires PNG charts but the source graphics are provided as SVG files.
 */
