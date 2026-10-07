// HOW-TO: Convert PDF with Vector Graphics to Selectable SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.pdf");
            string outputPath = Path.Combine("Output", "output.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed a PDF brochure on a website and want the graphics to scale without loss while keeping the text searchable and selectable.
 * 2. When generating responsive vector assets from engineering drawings stored as PDFs for use in web dashboards.
 * 3. When converting printable PDF invoices into SVG files so that customers can copy line‑item text directly from the browser.
 * 4. When creating an online documentation portal that requires high‑resolution diagrams from PDFs while preserving editable text for accessibility tools.
 * 5. When automating a workflow that transforms PDF marketing flyers into SVG icons for responsive UI components without rasterizing the artwork.
 */
