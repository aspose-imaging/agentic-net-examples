using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

namespace SvgToPngExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Ensure any runtime exception is reported cleanly
            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output directory
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Custom dimensions for the rasterized image
                int targetWidth = 300;   // desired width in pixels
                int targetHeight = 200;  // desired height in pixels

                // Open the SVG file as a stream and load it
                using (Stream stream = File.OpenRead(inputPath))
                using (SvgImage svgImage = new SvgImage(stream))
                {
                    // Configure rasterization options with the custom page size
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(targetWidth, targetHeight),
                        // Optional: set background color, smoothing, etc.
                        BackgroundColor = Color.White,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    };

                    // Set up PNG save options and attach rasterization settings
                    PngOptions saveOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the rasterized PNG image
                    svgImage.Save(outputPath, saveOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as 300 × 200 pixel PNG files for display in a product catalog.
 * 2. When an automated reporting tool must convert scalable vector diagrams stored as SVG into fixed‑size PNG images to embed in PDF reports that require a specific page layout.
 * 3. When a desktop utility processes a batch of SVG icons and rasterizes each to a uniform PNG size for use as Windows application assets.
 * 4. When an e‑learning platform creates course slides by rendering SVG illustrations to PNG at custom dimensions to ensure consistent rendering across different browsers.
 * 5. When a CI/CD pipeline validates design assets by programmatically converting SVG mockups to PNG with exact width and height before publishing them to a content delivery network.
 */