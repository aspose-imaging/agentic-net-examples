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

                // Configure SVG save options
                var saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Preserve selectable text (do NOT render as shapes)
                    TextAsShapes = false
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
 * 1. When a web developer wants to embed a PDF brochure with vector illustrations into a responsive website and needs the text to remain searchable and selectable, they can use this C# code to convert the PDF to SVG while preserving selectable text.
 * 2. When an e‑learning platform needs to transform lecture slides saved as PDF into scalable SVG graphics for interactive HTML5 viewers, this code provides a straightforward way to retain vector quality and editable text.
 * 3. When a marketing automation system generates PDF invoices that must be displayed in email newsletters as lightweight, resolution‑independent graphics, the code can convert them to SVG without turning the text into shapes.
 * 4. When a GIS application exports map data as PDF and requires the maps to be displayed on a web map client with selectable labels, developers can apply this code to produce SVG files that keep the text elements searchable.
 * 5. When a documentation portal wants to publish technical manuals originally authored in PDF as SVG for faster page loads and SEO‑friendly text indexing, this C# snippet enables the conversion while preserving the original vector graphics and selectable text.
 */