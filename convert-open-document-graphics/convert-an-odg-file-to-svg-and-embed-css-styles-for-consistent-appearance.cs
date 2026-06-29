using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.odg";
        string outputPath = @"C:\Output\sample.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions();

                // Set vector rasterization options (page size, etc.)
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    // Additional options can be set here if needed, e.g., TextAsShapes = false
                };

                svgOptions.VectorRasterizationOptions = vectorOptions;

                // Save as SVG; CSS styles are embedded automatically by Aspose.Imaging
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) created in LibreOffice Draw into scalable SVG files for responsive web pages while preserving styling through embedded CSS.
 * 2. When an automated build pipeline must generate SVG assets from ODG design files to include in a web application’s asset bundle without manual conversion.
 * 3. When a content management system imports user‑uploaded ODG diagrams and stores them as SVG with inline CSS for consistent rendering across browsers.
 * 4. When a reporting tool exports charts drawn in ODG format to SVG so that they can be styled uniformly with CSS in PDF or HTML reports.
 * 5. When a desktop application processes a batch of ODG icons and converts them to SVG with embedded CSS to ensure they scale correctly on high‑DPI displays.
 */