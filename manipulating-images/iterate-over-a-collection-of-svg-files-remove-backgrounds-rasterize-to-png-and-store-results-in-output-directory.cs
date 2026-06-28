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

                // Load SVG, remove background, rasterize to PNG, and save
                using (SvgImage svgImage = new SvgImage(inputPath))
                {
                    // Remove background from the SVG
                    svgImage.RemoveBackground();

                    // Set up rasterization options
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Set up PNG save options with rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized PNG
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
 * 1. When a developer needs to batch‑process a directory of SVG icons, remove their backgrounds, and generate transparent PNG files for use in a responsive web application.
 * 2. When an e‑commerce system must convert product vector illustrations from SVG to PNG with no background for inclusion in email campaigns and social media posts.
 * 3. When a design workflow requires automatically rasterizing SVG logos into PNG assets at their original size for printing or branding guidelines.
 * 4. When a content management platform has to prepare SVG diagrams for mobile devices by stripping backgrounds and saving them as PNG images to reduce rendering complexity.
 * 5. When a reporting tool needs to transform a collection of SVG charts into PNG images with transparent backgrounds for embedding in PDF reports.
 */