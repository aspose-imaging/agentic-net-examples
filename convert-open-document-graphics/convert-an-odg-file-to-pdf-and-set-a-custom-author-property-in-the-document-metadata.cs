// HOW-TO: Convert ODG to PDF and Set Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.odg";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options and set custom author metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Custom Author Name" }
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
 * 1. When you need to programmatically export OpenDocument graphics (ODG) files to PDF for distribution while embedding a specific author name in the PDF metadata.
 * 2. When an automated reporting system must generate PDF versions of ODG diagrams and ensure the author field reflects the document creator for compliance tracking.
 * 3. When a document management workflow requires converting user‑uploaded ODG assets to searchable PDF files and adding custom metadata for indexing.
 * 4. When a batch processing job has to convert multiple ODG drawings to PDF and uniformly apply a corporate author tag for branding purposes.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize ODG pages to PDF and embed author information for digital rights management.
 */
