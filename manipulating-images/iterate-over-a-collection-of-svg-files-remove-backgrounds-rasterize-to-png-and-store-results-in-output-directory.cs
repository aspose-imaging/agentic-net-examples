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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputSvgs";
            string outputDirectory = @"C:\OutputPngs";

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (SvgImage svgImage = new SvgImage(inputPath))
                {
                    // Remove background from the SVG
                    svgImage.RemoveBackground();

                    // Set up rasterization options
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Set up PNG save options with the rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save rasterized PNG
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
 * 1. When a developer needs to batch‑process a folder of SVG icons, strip any background layers, and generate transparent PNG assets for web or mobile apps.
 * 2. When an e‑commerce platform must convert product vector illustrations stored as SVG files into PNG thumbnails while ensuring the background is removed for seamless overlay on product pages.
 * 3. When a reporting tool requires converting SVG charts into high‑resolution PNG images for inclusion in PDF or email reports, and the background must be eliminated to match the document theme.
 * 4. When a game developer wants to import a library of SVG sprites, remove their backgrounds, and rasterize them to PNG files for use in the game engine’s texture pipeline.
 * 5. When an automated CI/CD pipeline needs to validate and transform SVG assets in a repository into background‑free PNGs before publishing them to a CDN or design system.
 */