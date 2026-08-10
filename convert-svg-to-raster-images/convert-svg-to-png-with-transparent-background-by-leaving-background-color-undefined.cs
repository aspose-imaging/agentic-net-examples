// HOW-TO: Convert SVG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options for a transparent background
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Do not set a background color (or set to Transparent)
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    // Use the original SVG size
                    PageSize = svgImage.Size
                };

                // Indicate that the image has no background color
                svgImage.HasBackgroundColor = false;

                // Prepare PNG save options and attach rasterization settings
                var pngOptions = new PngOptions
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
 * 1. When you need to display vector icons on a web page with varying backgrounds, you can rasterize the SVG to a PNG that retains transparency using Aspose.Imaging in C#.
 * 2. When generating product thumbnails for an e‑commerce platform, converting SVG logos to transparent PNGs ensures they overlay correctly on different colored promotional banners.
 * 3. When creating PDF reports that embed images, converting SVG diagrams to transparent PNGs allows the diagrams to blend seamlessly with the report’s background colors.
 * 4. When building a desktop application that caches vector graphics as raster images, you can use this code to store SVG assets as transparent PNG files for faster rendering.
 * 5. When automating a CI/CD pipeline that prepares assets for mobile apps, converting SVG assets to transparent PNGs guarantees the icons appear correctly on both light and dark themes.
 */
