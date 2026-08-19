// HOW-TO: Convert OTG to PDF and Set Custom Author in C# (Aspose.Imaging for .NET)
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
                // Configure rasterization options for OTG
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare PDF save options
                var pdfOptions = new PdfOptions
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
 * 1. When you need to generate a searchable PDF from an OTG vector image while preserving the original page size.
 * 2. When you must embed a specific author name into the PDF metadata for compliance or branding purposes.
 * 3. When an automated workflow converts a batch of OTG files to PDFs for archival in a document management system.
 * 4. When a web service receives OTG uploads and returns PDF files with custom metadata for downstream processing.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize OTG graphics into PDF format for printing or distribution.
 */
