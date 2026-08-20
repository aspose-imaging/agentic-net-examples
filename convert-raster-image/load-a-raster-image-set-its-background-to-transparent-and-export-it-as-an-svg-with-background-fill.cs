// HOW-TO: Convert PNG to SVG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure SVG rasterization options with transparent background
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = image.Size
                };

                // Set up SVG save options
                var saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to embed a PNG logo into a web page as a scalable SVG without any background color.
 * 2. When converting scanned bitmap graphics to vector‑friendly SVG files while preserving transparency for overlay in UI designs.
 * 3. When preparing assets for responsive design, turning raster icons into SVGs that keep a transparent canvas for dynamic theming.
 * 4. When automating batch processing of product images to generate SVG versions that can be tinted or styled without a solid background.
 * 5. When integrating Aspose.Imaging in a C# application to export images for print‑ready PDFs where the SVG must have no background fill.
 */
