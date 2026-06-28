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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Desired raster dimensions
            int targetWidth = 800;
            int targetHeight = 600;

            // Load the SVG image from file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options with custom page size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(targetWidth, targetHeight),
                    // Optional: set background color, smoothing, etc.
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Set PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as 800×600 PNG files for display in a product catalog.
 * 2. When an automated reporting tool must convert vector‑based SVG charts into raster PNG images with a specific page size to embed in PDF reports.
 * 3. When a desktop utility has to batch‑process SVG icons and output them as PNG assets with a white background for use in a Windows application UI.
 * 4. When a CI/CD pipeline requires rendering SVG diagrams to PNG at custom dimensions to verify visual consistency before deployment.
 * 5. When a mobile app backend needs to serve PNG versions of scalable SVG illustrations at a fixed resolution for devices that do not support SVG rendering.
 */