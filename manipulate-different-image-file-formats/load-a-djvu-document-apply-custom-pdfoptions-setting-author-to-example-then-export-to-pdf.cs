using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Example" }
                };

                djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert archived DjVu scans of historical documents into searchable PDF files while embedding author metadata for compliance.
 * 2. When an application must batch‑process user‑uploaded DjVu e‑books and generate PDF versions with a predefined author name for digital library cataloging.
 * 3. When a document management system requires on‑the‑fly conversion of DjVu engineering drawings to PDF while preserving the creator’s information for version control.
 * 4. When a web service offers file format conversion from DjVu to PDF and needs to set the PDF’s author field programmatically using C# and Aspose.Imaging.
 * 5. When a desktop utility automates the migration of legacy DjVu marketing brochures to PDF, adding the company’s name as the author to maintain branding consistency.
 */