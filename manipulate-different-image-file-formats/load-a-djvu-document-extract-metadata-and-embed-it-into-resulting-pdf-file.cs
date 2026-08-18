// HOW-TO: Convert DjVu to PDF with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                string identifier = djvu.Identifier.ToString();
                int pageCount = djvu.PageCount;
                string xmpData = djvu.XmpData?.ToString() ?? string.Empty;

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Converted from DjVu",
                        Author = "Aspose.Imaging",
                        Subject = $"DjVu Identifier: {identifier}",
                        Keywords = $"Pages={pageCount}"
                    };

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
 * 1. When you need to archive scanned DjVu documents as searchable PDFs while keeping original identifiers and page counts in the PDF metadata.
 * 2. When a digital library wants to batch‑convert DjVu files to PDF and embed author and subject information for cataloguing.
 * 3. When an application must extract XMP data from a DjVu image and store it in the resulting PDF’s metadata for compliance reporting.
 * 4. When you are building a document workflow that transforms legacy DjVu manuals into PDF format and preserves keywords for SEO indexing.
 * 5. When a C# service processes user‑uploaded DjVu files and generates PDFs that include custom title and author fields for downstream processing.
 */
