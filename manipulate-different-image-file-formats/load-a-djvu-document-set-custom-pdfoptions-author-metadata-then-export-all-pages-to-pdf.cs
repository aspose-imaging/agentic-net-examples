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
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Custom Author" }
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
 * 1. When a developer needs to convert multi‑page DjVu scans of historical books into searchable PDF files while embedding the author's name in the PDF metadata using Aspose.Imaging for .NET.
 * 2. When an application must automate the migration of DjVu‑based technical manuals to PDF format and ensure the resulting PDFs contain custom author information for compliance reporting.
 * 3. When a digital archive workflow requires extracting all pages from a DjVu document and saving them as a single PDF with proper PDF document info, such as the author, to improve cataloging and retrieval.
 * 4. When a C# service processes user‑uploaded DjVu files and needs to generate PDF versions with embedded metadata so that downstream PDF viewers display the correct author attribution.
 * 5. When a batch job needs to read DjVu images from a folder, convert each to PDF, and set a custom author field programmatically to maintain consistent branding across all exported PDF reports.
 */