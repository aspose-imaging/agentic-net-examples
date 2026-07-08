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

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options with the source page size
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options: keep text as selectable (TextAsShapes = false)
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    TextAsShapes = false
                };

                // Save the PDF as SVG
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
 * 1. When a developer needs to embed a PDF brochure with vector graphics into a responsive web page while keeping the text selectable, they can convert the PDF to SVG using this code.
 * 2. When an e‑learning platform wants to display high‑resolution diagrams from PDF lecture notes on browsers without losing scalability, the code can rasterize the PDF pages to SVG while preserving selectable text.
 * 3. When a SaaS application generates printable invoices as PDFs but also requires a web‑friendly version for online viewing, this snippet converts the PDF to SVG so the text stays searchable and the graphics remain crisp.
 * 4. When a content management system must automatically transform uploaded PDF marketing assets into SEO‑friendly SVG assets for web publishing, the code provides a C# solution that keeps text as text nodes.
 * 5. When a developer is building an automated workflow that extracts vector graphics from PDF reports and serves them as interactive SVGs in a dashboard, this example shows how to load the PDF and save it as SVG with selectable text.
 */