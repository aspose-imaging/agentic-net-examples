// HOW-TO: Convert SVG to PNG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        try
        {
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
                // Set up rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
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
 * 1. When you need to programmatically turn user‑uploaded SVG graphics into PNG thumbnails for a web application using C#.
 * 2. When you must generate high‑quality raster images from vector logos stored as SVG files for PDF reports in a .NET service.
 * 3. When an e‑commerce platform requires converting scalable product illustrations (SVG) to PNG for email newsletters.
 * 4. When a desktop utility needs to batch‑process SVG assets into PNG format while preserving original dimensions with Aspose.Imaging.
 * 5. When a mobile backend service must accept SVG uploads via an API and return PNG files for display on devices that only support raster images.
 */
