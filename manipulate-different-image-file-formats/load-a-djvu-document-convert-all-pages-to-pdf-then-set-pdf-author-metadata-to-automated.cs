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
            string inputPath = "input.djvu";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = File.OpenRead(inputPath))
            using (Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = new Aspose.Imaging.FileFormats.Djvu.DjvuImage(stream))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(); // export all pages
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Author = "Automated" };

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
 * 1. When an archival system receives scanned documents in DjVu format and must generate searchable multi‑page PDFs with a consistent author tag for compliance reporting.
 * 2. When a batch‑processing service needs to convert user‑uploaded DjVu ebooks into PDF files while automatically embedding the author metadata as "Automated" for downstream indexing.
 * 3. When a document‑management workflow requires converting multi‑page DjVu blueprints to PDF portfolios and setting the PDF author field to identify the conversion script.
 * 4. When a legal‑tech application must transform DjVu case files into PDF format for court submission, ensuring the PDF metadata records the automated processing source.
 * 5. When a cloud‑based image‑processing API offers a C# endpoint that takes DjVu input, outputs a single PDF containing all pages, and adds the author metadata to track automated conversions.
 */