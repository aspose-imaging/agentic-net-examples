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
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "Output\\output.pdf";

        // Ensure any exception is caught and reported
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Prepare PDF save options with author metadata
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Automated";

                // Save all pages of the DjVu document to a single PDF file
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
 * 1. When a document management system receives scanned archives in DjVu format and must store them as searchable PDFs with a consistent author tag for audit trails.
 * 2. When an automated batch job processes legacy DjVu manuals and converts each file to a single PDF while embedding “Automated” as the author to indicate machine‑generated output.
 * 3. When a web service allows users to upload DjVu drawings and returns a PDF version with metadata that identifies the conversion source as an automated process.
 * 4. When a legal e‑discovery workflow needs to normalize evidence files by turning multi‑page DjVu files into PDFs and tagging them with a standard author name for indexing.
 * 5. When a desktop utility in C# converts DjVu e‑books to PDF for e‑readers and sets the author metadata to “Automated” so the reader app can group all converted books together.
 */