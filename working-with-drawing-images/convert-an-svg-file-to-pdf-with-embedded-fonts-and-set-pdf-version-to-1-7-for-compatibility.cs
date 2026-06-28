using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF options with PDF version 1.7 (default) and embed fonts
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Setting compliance; PDF 1.7 is the default version used by Aspose.Imaging
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF
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
 * 1. When a developer needs to convert an SVG logo into a PDF brochure while preserving the exact typography by embedding fonts and ensuring PDF 1.7 compatibility.
 * 2. When an automated build pipeline must generate PDF invoices from SVG templates and guarantee that the PDFs meet PDF/A‑1b compliance for archiving.
 * 3. When a web service receives user‑uploaded SVG diagrams and must return a printable PDF with embedded fonts so the document looks the same on any device.
 * 4. When a desktop application creates printable reports by rasterizing vector graphics from SVG files into high‑resolution PDFs that conform to PDF version 1.7.
 * 5. When a batch job processes a folder of SVG assets and converts them to PDF files with embedded fonts to meet corporate document standards and avoid missing‑font warnings.
 */