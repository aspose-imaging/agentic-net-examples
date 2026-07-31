using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\diagram.pdf";
        string outputPath = "Output\\diagram.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    // Set up vector rasterization options to preserve original dimensions and line widths
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White,
                        SmoothingMode = SmoothingMode.None,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    };

                    svgOptions.VectorRasterizationOptions = rasterOptions;
                    svgOptions.TextAsShapes = true; // Preserve text as shapes for accurate scaling

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
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
 * 1. When a developer needs to convert engineering PDF schematics into scalable SVG files for a web‑based viewer while preserving exact line widths for accurate zooming, this code provides a reliable C# solution using Aspose.Imaging.
 * 2. When a design team wants to transform vector‑based PDF illustrations into SVG icons for responsive UI layouts, ensuring that stroke thickness remains consistent across different screen resolutions, the sample demonstrates the required image processing steps.
 * 3. When a documentation system must migrate legacy PDF diagrams to SVG format for searchable, searchable‑by‑machine‑learning content without losing the original drawing dimensions, the code handles the conversion with proper rasterization options.
 * 4. When an e‑learning platform requires high‑quality SVG assets generated from PDF lecture slides so that mathematical graphs retain their precise line weights during scaling, this C# example shows how to achieve that using Aspose.Imaging.
 * 5. When a GIS application needs to import PDF map overlays as SVG layers while keeping the original line styles intact for accurate geographic scaling, the provided code performs the conversion with line‑width preservation.
 */