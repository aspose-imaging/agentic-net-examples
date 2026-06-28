using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

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
                // Configure rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Attempt to save and catch any exceptions specific to saving
                try
                {
                    image.Save(outputPath, pngOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error saving {outputPath}: {ex.Message}");
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
 * 1. When a web service converts user‑uploaded SVG logos to PNG thumbnails and needs to log any file‑system or rasterization errors with the target path.
 * 2. When an automated build pipeline generates PNG assets from design SVG files and must capture save failures to prevent silent build breaks.
 * 3. When a desktop application batch‑processes a folder of SVG diagrams into PNG reports and wants to record which output files failed to save.
 * 4. When a cloud function transforms SVG charts into PNG images for email attachments and requires detailed error messages for troubleshooting.
 * 5. When a CI/CD script validates SVG to PNG conversion in a .NET project and needs to output the exact file path and exception details on failure.
 */