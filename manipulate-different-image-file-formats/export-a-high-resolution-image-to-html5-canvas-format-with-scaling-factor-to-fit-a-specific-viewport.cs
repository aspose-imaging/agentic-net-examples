// HOW-TO: Export Scaled SVG to HTML5 Canvas with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.svg";
            string outputPath = @"C:\Images\output.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage image = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with scaling to fit a specific viewport
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Example: scale to 50% of original size (adjust as needed)
                    ScaleX = 0.5f,
                    ScaleY = 0.5f,
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Set HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    FullHtmlPage = true // generate a full HTML page
                };

                // Export to HTML5 Canvas format
                image.Save(outputPath, canvasOptions);
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
 * 1. When you need to embed a high‑resolution SVG in a web page using an HTML5 canvas that automatically scales to a specific viewport size.
 * 2. When you want to generate a full HTML page from an SVG for offline viewing while preserving vector quality with a custom scaling factor.
 * 3. When a web application must convert user‑uploaded SVG files to canvas‑based graphics to ensure consistent rendering across browsers.
 * 4. When you are building a reporting tool that exports charts stored as SVG into HTML5 canvas elements sized to fit printable page dimensions.
 * 5. When you need to programmatically resize and rasterize SVG assets for responsive design without losing detail, using C# and Aspose.Imaging.
 */
