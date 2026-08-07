using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for PDF pages
            string outputDir = @"C:\Temp\PdfPages";

            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(outputDir);

            // Set memory optimization options (limit internal buffers to 1 MB)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Load the DjVu document with the specified load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Iterate through each page and save it as a separate PDF file
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.pdf");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PDF using PdfOptions
                    PdfOptions pdfOptions = new PdfOptions();
                    page.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert a multi‑page DjVu document to individual PDF files while running on a server with limited RAM, they can use Aspose.Imaging for .NET with a 1 MB BufferSizeHint to optimize memory usage.
 * 2. When an archival system must extract each page of a scanned DjVu file and store it as a separate searchable PDF for compliance reporting, this code provides a straightforward C# solution.
 * 3. When a desktop application processes large DjVu ebooks on low‑end machines and must prevent out‑of‑memory exceptions, the LoadOptions.BufferSizeHint setting ensures efficient page‑by‑page conversion to PDF.
 * 4. When an automated workflow needs to transform incoming DjVu submissions into PDF pages for downstream OCR or indexing services, the Aspose.Imaging API can load the document, iterate over DjvuPage objects, and save them as PDFs.
 * 5. When a cloud‑based microservice receives DjVu uploads and must deliver each page as an individual PDF document without consuming excessive memory, the provided C# code demonstrates the optimal approach using DjvuImage.LoadDocument and PdfOptions.
 */