using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/multipage.svg";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page SVG document
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Configure vector rasterization to preserve vector fidelity
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Save all pages to a single PDF file
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a printable catalog from a multi‑page SVG brochure, preserving vector quality and page order in a single PDF for distribution.
 * 2. When an engineering application must export multi‑layer SVG schematics as a consolidated PDF report without rasterizing the graphics.
 * 3. When a web service creates downloadable invoices that are designed as separate SVG pages and must be merged into one PDF for client download.
 * 4. When a document management system ingests multi‑page SVG drawings and needs to archive them as a single searchable PDF while keeping exact dimensions.
 * 5. When an automated build pipeline converts SVG UI mockups into a single PDF handbook, ensuring the vector fidelity remains intact for high‑resolution printing.
 */