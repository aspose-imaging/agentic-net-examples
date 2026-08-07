using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Cache data to avoid lazy loading
                image.CacheData();

                // Get the first page (flattened during rasterization)
                var page = (CdrImagePage)image.Pages[0];

                // Set up rasterization options for PDF export
                var rasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };

                // Configure PDF options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the page as PDF
                page.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to automatically convert multi‑layer CorelDRAW CDR artwork into a single‑page PDF for client review or printing, they can use this code to flatten the layers and export the drawing.
 * 2. When a document management system must ingest legacy CDR files and store them as searchable PDF documents, developers can employ this snippet to rasterize and save the drawings in PDF format.
 * 3. When an e‑commerce platform wants to generate product catalog pages from CorelDRAW designs without manual export, the code can programmatically load the CDR, flatten its layers, and produce a PDF ready for web publishing.
 * 4. When a legal compliance workflow requires archiving engineering schematics originally created in CorelDRAW as immutable PDF records, this C# example provides a reliable way to convert and flatten the files.
 * 5. When a batch‑processing tool needs to convert a folder of CDR files to PDF while preserving exact dimensions and text rendering, the shown Aspose.Imaging routine can be integrated to automate the conversion.
 */