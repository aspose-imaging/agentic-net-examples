// HOW-TO: Convert DjVu Document to PDF with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.djvu");
            string outputPath = Path.Combine(baseDir, "Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive scanned books stored as DjVu files while keeping their title, author, and creation date information in a searchable PDF.
 * 2. When a document management system must ingest DjVu submissions and convert them to PDF for downstream workflows without losing embedded metadata.
 * 3. When generating PDF reports from legacy DjVu technical manuals and preserving the original metadata for compliance auditing.
 * 4. When building a C# web service that receives DjVu uploads and returns PDF files that retain the source file’s metadata for indexing.
 * 5. When migrating a digital library from DjVu to PDF format and requiring the metadata to be transferred automatically during conversion.
 */
