// HOW-TO: Convert DjVu Document To Multi‑Page PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
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

            using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to programmatically convert a multi‑page DjVu file into a single PDF while keeping the original layout using C#.
 * 2. When you want to integrate DjVu to PDF conversion into a document‑management system that stores all pages in one PDF file.
 * 3. When you are building a batch‑processing tool that reads DjVu ebooks and outputs combined PDF versions for readers who only support PDF.
 * 4. When you must generate PDF reports from DjVu technical manuals on the fly in a .NET application.
 * 5. When you need to automate the migration of legacy DjVu archives to PDF for compliance or backup purposes.
 */
