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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Input\sample.pdf";
            string outputPath = @"C:\Output\sample.pdf.svg";

            // Verify that the input PDF exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF (vector image) using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Preserve the original page size
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    // Render text as shapes to keep editability
                    TextAsShapes = true,
                    // Apply the rasterization settings defined above
                    VectorRasterizationOptions = rasterOptions,
                    // Keep original metadata (optional, but helps preserve layers)
                    KeepMetadata = true
                };

                // Save the PDF as an SVG file, preserving layer hierarchy
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
 * 1. When a developer needs to convert a multi‑page PDF containing vector graphics into editable SVG files while preserving the original layer hierarchy for further editing in tools like Adobe Illustrator or Inkscape.
 * 2. When an automated build pipeline must generate scalable SVG assets from PDF design documents to embed in web applications without losing vector quality.
 * 3. When a C# service processes uploaded PDF brochures and outputs SVG versions so that marketing teams can modify individual layers in a design editor.
 * 4. When a desktop utility has to batch‑convert engineering drawings stored as PDF into SVG while keeping text as shapes for precise typography editing.
 * 5. When a document management system requires extracting vector artwork from PDFs and storing them as SVGs with metadata intact for searchable archival.
 */