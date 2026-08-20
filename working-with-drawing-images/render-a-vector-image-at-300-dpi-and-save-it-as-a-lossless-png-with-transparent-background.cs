// HOW-TO: Render SVG to 300 DPI Transparent PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\result.png";

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
                // Configure rasterization options: transparent background and page size matching the SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                };

                // Configure PNG options: 300 DPI resolution and attach rasterization options
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as a lossless PNG with transparent background
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
 * 1. When you need to convert scalable vector graphics into high‑resolution PNGs for print‑ready assets while preserving transparency.
 * 2. When generating thumbnails or previews of SVG icons at 300 DPI for UI designs that require lossless quality.
 * 3. When exporting SVG diagrams to PNG for inclusion in PDF reports where exact dimensions and a transparent background are required.
 * 4. When automating a build pipeline that rasterizes vector logos into 300 DPI PNGs to meet branding guidelines.
 * 5. When creating web‑ready images from SVG illustrations that must retain transparency and meet specific DPI specifications.
 */
