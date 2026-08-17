// HOW-TO: Align SVG DPI Before Rasterizing to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
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
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options to align DPI (use same scale for X and Y)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = svgImage.Size,
                    // Ensure uniform scaling (same DPI for both axes)
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                };

                // Prepare PNG save options and attach rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG
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
 * 1. When you need to convert an SVG logo to a PNG thumbnail while preserving the original DPI for consistent display on web pages.
 * 2. When generating print‑ready PNG assets from vector diagrams and must ensure both X and Y axes have the same resolution.
 * 3. When automating batch processing of SVG icons to PNG format in a CI pipeline and want uniform scaling across all images.
 * 4. When embedding SVG graphics into a PDF and require a rasterized PNG version with matching DPI to avoid blurry output.
 * 5. When creating responsive UI assets where the PNG must match the SVG’s size and DPI to maintain visual fidelity across devices.
 */
