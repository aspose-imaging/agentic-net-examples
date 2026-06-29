using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for OTG
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF save options and set custom author metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
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
 * 1. When a medical imaging system needs to archive OTG vector graphics as searchable PDFs with a specific author name for regulatory compliance.
 * 2. When an engineering design tool exports OTG schematics and wants to bundle them into PDFs that include the designer’s name in the document metadata.
 * 3. When a publishing workflow converts OTG illustrations into PDF brochures while embedding the editor’s name as the author property for branding.
 * 4. When a legal document management solution transforms OTG diagrams into PDFs and records the attorney’s name in the PDF metadata for audit trails.
 * 5. When an automated batch process generates PDF manuals from OTG assets and sets a custom author field to identify the content creator.
 */