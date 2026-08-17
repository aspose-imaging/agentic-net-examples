// HOW-TO: Convert PDF with Vector Graphics to SVG Keeping Text Selectable in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.pdf";
            string outputPath = @"C:\Output\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options (page size matches source)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options: keep text as selectable (not shapes)
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    TextAsShapes = false
                };

                // Save as SVG
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
 * 1. When you need to embed a PDF diagram on a website and want the SVG to retain searchable, selectable text for better accessibility.
 * 2. When converting engineering drawings from PDF to SVG so that the vector shapes stay crisp while the annotations remain editable in the browser.
 * 3. When creating responsive web graphics from PDF brochures and require the text elements to remain searchable for SEO purposes.
 * 4. When automating a workflow that extracts vector‑based charts from PDF reports and saves them as SVG files that can be styled with CSS.
 * 5. When building a .NET application that transforms PDF invoices into SVG format while preserving the text fields for client‑side data extraction.
 */
