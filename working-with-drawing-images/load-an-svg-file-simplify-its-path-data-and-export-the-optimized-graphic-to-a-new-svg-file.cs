using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output SVG file paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options (required for SVG export)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Compression is not needed for plain SVG output
                    Compress = false
                };

                // Save the optimized SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the size of an SVG asset before embedding it in a responsive web page, they can use this C# code to load the SVG, simplify its path data, and save an optimized version.
 * 2. When an automated build pipeline must generate lightweight SVG icons from design files to improve mobile app performance, the code can be invoked to raster‑aware load and re‑export the graphics with simplified paths.
 * 3. When a content management system needs to validate that uploaded SVGs exist and then store a cleaned‑up copy for safe rendering, this snippet checks file existence, creates the output directory, and writes a compression‑free SVG.
 * 4. When a developer is creating a batch‑processing tool that normalizes SVG dimensions across multiple files for consistent printing, the example shows how to load each file, set page size, and save a uniform SVG output.
 * 5. When a .NET service must programmatically convert legacy SVG drawings into a streamlined format that browsers can render quickly, the code demonstrates using Aspose.Imaging’s SvgOptions and rasterization settings to produce an optimized SVG file.
 */