// HOW-TO: Batch Remove Background from SVGs and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputSvgs";
        string outputDirectory = @"C:\OutputPngs";

        try
        {
            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PNG path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG, remove background, rasterize to PNG, and save
                using (SvgImage svgImage = new SvgImage(inputPath))
                {
                    // Remove any background from the SVG
                    svgImage.RemoveBackground();

                    // Set up rasterization options (use the original SVG size)
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Set up PNG save options with the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the rasterized image as PNG
                    svgImage.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to clean up a large set of SVG icons by removing their backgrounds before converting them to PNGs for use in a web application.
 * 2. When you want to automate the preparation of SVG logos for inclusion in PDF reports, ensuring they are rasterized to PNG with transparent backgrounds.
 * 3. When an e‑commerce platform requires product vector images to be batch‑converted to PNG thumbnails without any background to improve page load speed.
 * 4. When a mobile app development workflow demands converting SVG assets to PNG format while stripping backgrounds for consistent UI rendering.
 * 5. When a CI/CD pipeline must process design assets, removing backgrounds from SVG files and rasterizing them to PNGs for deployment to a content delivery network.
 */
