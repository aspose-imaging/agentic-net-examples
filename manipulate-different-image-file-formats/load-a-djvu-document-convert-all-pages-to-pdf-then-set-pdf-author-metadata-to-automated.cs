using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.FileFormats.Djvu.DjvuImage djvu = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(),
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Automated" }
                };

                djvu.Save(outputPath, pdfOptions);
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
 * 1. When a company needs to batch‑convert archived DjVu scans of historical documents into searchable PDF files and automatically set the PDF author metadata to “Automated” for consistent cataloging.
 * 2. When an engineering team wants to generate PDF reports from multi‑page DjVu technical drawings in a C# application while embedding author information for compliance tracking.
 * 3. When a digital library migrates its DjVu e‑books to PDF format using Aspose.Imaging for .NET and requires uniform author metadata for library management systems.
 * 4. When a server‑side service receives DjVu files, converts each page to a single PDF document, and tags the PDF with the author “Automated” to integrate with downstream workflow automation.
 * 5. When a desktop utility processes DjVu invoices, converts them to PDF, and embeds the author metadata to indicate the files were produced by an automated process.
 */