// HOW-TO: Convert PDF Vector Artwork to Editable SVG with Layers in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

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

            // Load the PDF document (vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG export
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    // Render text as shapes to keep editability
                    TextAsShapes = true
                };

                // Save the PDF as SVG, preserving layer hierarchy
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
 * 1. When a developer needs to transform a multi‑page PDF containing vector graphics into an SVG file that retains the original layer structure for further editing in tools like Adobe Illustrator or Inkscape.
 * 2. When building an automated workflow that extracts scalable artwork from PDF brochures and converts it to SVG so web designers can reuse the graphics on responsive websites.
 * 3. When migrating legacy design assets from PDF to a modern vector format while keeping text editable as shapes for precise typography adjustments in downstream applications.
 * 4. When creating a batch conversion utility that prepares PDF schematics for inclusion in documentation systems that only accept SVG, ensuring the visual fidelity and layer hierarchy remain intact.
 * 5. When integrating PDF‑to‑SVG conversion into a C# application that generates printable marketing materials, allowing designers to fine‑tune individual layers after conversion.
 */
