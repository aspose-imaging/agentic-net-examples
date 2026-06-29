using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (SVG)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Transparent background
                    BackgroundColor = Color.Transparent,
                    // Preserve original size
                    PageSize = image.Size,
                    // High-quality rendering
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    // Attach rasterization options
                    VectorRasterizationOptions = rasterOptions,
                    // Set resolution to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    // No compression for lossless output
                    PngCompressionLevel = PngCompressionLevel.ZipLevel0
                };

                // Save the rasterized image as PNG
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
 * 1. When a web developer needs to convert scalable SVG icons into high‑resolution 300 DPI PNG files with a transparent background for retina displays.
 * 2. When a desktop application must generate print‑ready product labels from vector templates, preserving exact dimensions and lossless quality.
 * 3. When an e‑learning platform wants to rasterize SVG diagrams into PNG assets for inclusion in PDF handouts while maintaining transparency.
 * 4. When a UI designer automates the creation of asset bundles, turning vector UI elements into PNG sprites at 300 DPI for game engines that require raster images.
 * 5. When a reporting service exports vector charts as lossless PNG images with transparent backgrounds to embed in PowerPoint presentations without background artifacts.
 */