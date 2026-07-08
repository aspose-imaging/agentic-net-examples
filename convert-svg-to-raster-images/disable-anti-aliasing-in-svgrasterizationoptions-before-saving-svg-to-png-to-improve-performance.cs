using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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

        try
        {
            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set the page size to match the SVG dimensions
                    PageSize = svgImage.Size,
                    // Disable anti‑aliasing for performance
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Set up PNG save options with the rasterization settings
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When generating thumbnail previews of a large batch of SVG icons for a web catalog, disabling anti‑aliasing in SvgRasterizationOptions speeds up the C# PNG conversion without requiring smooth edges.
 * 2. When converting SVG diagrams to PNG for real‑time reporting dashboards, turning off smoothing reduces processing time and improves overall performance.
 * 3. When processing SVG maps on a server to produce PNG tiles for a GIS application, disabling anti‑aliasing minimizes CPU usage during rasterization.
 * 4. When creating PNG assets from SVG logos for email newsletters that are displayed at small sizes, disabling smoothing accelerates the build pipeline while preserving acceptable visual quality.
 * 5. When automating PDF generation that embeds PNG versions of SVG charts, turning off anti‑aliasing in the rasterization options speeds up the conversion step in the C# workflow.
 */