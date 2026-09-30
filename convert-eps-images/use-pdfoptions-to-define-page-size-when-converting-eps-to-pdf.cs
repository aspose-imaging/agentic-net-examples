// HOW-TO: Convert EPS to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When a graphic designer needs to embed an EPS illustration into a PDF report and must set the PDF page dimensions to match the original artwork.
 * 2. When an automated publishing system converts vector EPS logos to PDF files sized for standard A4 or Letter paper before sending them to a print service.
 * 3. When a web application generates PDF invoices that include EPS diagrams and requires consistent page sizing for proper layout across browsers.
 * 4. When a batch processing script converts a library of EPS files to PDF while specifying custom page widths for integration into an e‑book format.
 * 5. When a document management workflow extracts EPS drawings from CAD exports and saves them as PDFs with predefined page sizes for archival compliance.
 */
