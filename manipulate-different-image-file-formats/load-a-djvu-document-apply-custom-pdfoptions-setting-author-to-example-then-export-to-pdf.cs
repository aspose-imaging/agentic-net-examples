// HOW-TO: Convert DjVu to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Djvu.DjvuImage image = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Author = "Example" };
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
 * 1. When you need to archive scanned DjVu documents as searchable PDFs while embedding the author's name for proper attribution.
 * 2. When a digital library application must batch‑convert DjVu files to PDF and set consistent metadata before publishing.
 * 3. When generating PDF reports from DjVu source files and you want to programmatically assign the author field using C#.
 * 4. When integrating Aspose.Imaging into a document‑management system to transform DjVu images into PDFs with custom document information.
 * 5. When creating PDFs from DjVu e‑books and need to ensure the author metadata complies with PDF standards for downstream processing.
 */
