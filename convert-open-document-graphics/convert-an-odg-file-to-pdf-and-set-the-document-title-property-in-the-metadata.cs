// HOW-TO: Convert ODG to PDF and Set Document Title in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Title = "Document Title";
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
 * 1. When you need to generate a searchable PDF from an OpenDocument Graphics (ODG) file while embedding a custom title for document management systems.
 * 2. When automating batch conversion of ODG diagrams to PDF for archiving and you want each PDF to carry a specific title in its metadata.
 * 3. When integrating Aspose.Imaging into a C# application to export ODG drawings as PDFs and ensure the PDF’s Title property is set for better accessibility.
 * 4. When creating reports that include ODG illustrations and you must provide a PDF version with a predefined title for compliance or branding purposes.
 * 5. When developing a workflow that converts user‑uploaded ODG files to PDF and you need to programmatically assign the document title for downstream indexing.
 */
