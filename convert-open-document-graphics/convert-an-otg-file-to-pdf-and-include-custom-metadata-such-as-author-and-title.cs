// HOW-TO: Convert OTG to PDF with Custom Author and Title in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\input\sample.otg";
            string outputPath = @"C:\output\sample.pdf";

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
                // Configure PDF options with custom metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "John Doe",
                        Title = "Sample OTG to PDF"
                    }
                };

                // Set rasterization options for OTG conversion
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original page size
                };
                pdfOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save the image as PDF with the specified options
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
 * 1. When you need to generate a searchable PDF from an OTG design file while embedding the creator’s name and document title for compliance reporting.
 * 2. When an automated document pipeline must convert multiple OTG images to PDFs and preserve original page dimensions with custom metadata for archival systems.
 * 3. When a web service receives OTG uploads and must return PDFs that include author information for digital rights management.
 * 4. When integrating Aspose.Imaging into a C# application to batch‑process engineering drawings, adding consistent metadata before storing them in a document management repository.
 * 5. When creating printable PDFs from OTG files in a Windows desktop tool and you want the output files to carry specific author and title properties for easy identification.
 */
