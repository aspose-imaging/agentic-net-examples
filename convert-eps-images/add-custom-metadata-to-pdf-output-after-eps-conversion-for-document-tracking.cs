// HOW-TO: Add Custom Metadata When Converting EPS to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Document Tracking ID: 12345",
                        Author = "TrackingSystem",
                        Subject = "EPS to PDF conversion",
                        Keywords = "Tracking, EPS, PDF"
                    };

                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a company needs to embed a tracking ID into PDFs generated from EPS artwork for audit trails.
 * 2. When an automated publishing system converts designer EPS files to PDF and must include author and subject information for cataloging.
 * 3. When a legal department requires PDF metadata such as keywords and title to be set during batch conversion of EPS contracts.
 * 4. When a document management solution adds custom PDF metadata to support search indexing after converting EPS diagrams.
 * 5. When a workflow integrates Aspose.Imaging in C# to convert EPS logos to PDF while preserving metadata for brand compliance.
 */
