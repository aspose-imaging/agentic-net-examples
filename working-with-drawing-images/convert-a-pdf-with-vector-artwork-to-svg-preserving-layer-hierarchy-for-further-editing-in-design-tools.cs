using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.pdf";
            string outputPath = @"C:\Data\sample.pdf.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF (vector image) and convert it to SVG
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options – keep original page size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    // Preserve text as text (set to false) to keep editability of layers
                    TextAsShapes = false
                };

                // Save as SVG, preserving layer hierarchy
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
 * 1. When a developer needs to convert a PDF containing vector artwork into an SVG file while preserving the original layer hierarchy for further editing in tools like Adobe Illustrator.
 * 2. When an automated C# workflow must extract scalable vector graphics from PDF documents and output SVGs that retain text as editable text rather than rasterized shapes.
 * 3. When a .NET application processes engineering drawings stored as PDFs and requires SVG output with exact page dimensions and preserved vector layers for integration into a CAD viewer.
 * 4. When a document management system needs to transform uploaded PDF brochures into SVG assets on‑the‑fly so that front‑end designers can manipulate individual layers without losing vector quality.
 * 5. When a batch‑processing service converts multiple PDF marketing assets into lightweight SVGs, keeping the vector hierarchy intact for responsive UI rendering in cross‑platform applications.
 */