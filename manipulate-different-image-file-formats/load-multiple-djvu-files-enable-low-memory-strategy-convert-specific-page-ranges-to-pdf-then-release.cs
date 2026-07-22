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
            // Hardcoded input DjVu files
            string[] inputPaths = {
                @"C:\Data\sample1.djvu",
                @"C:\Data\sample2.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Data\ConvertedPdf";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Define page range to convert (e.g., pages 1 to 3)
            int[] pagesToConvert = { 1, 2, 3 };
            var multiPageOptions = new DjvuMultiPageOptions(pagesToConvert);

            // Low‑memory load options (1 MB buffer)
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024
            };

            foreach (string inputPath in inputPaths)
            {
                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists (already created above, but follow rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document with low‑memory strategy
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Save selected pages to PDF
                    var pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };
                    djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When a document management system must batch‑convert large DjVu archives to PDF while only extracting the first three pages to save storage and processing time, developers can use this low‑memory loading strategy.
 * 2. When a legal firm needs to generate PDF excerpts from multiple multi‑page DjVu case files on a workstation with limited RAM, the code enables selective page conversion without loading entire documents.
 * 3. When an e‑learning platform automatically prepares printable PDFs from uploaded DjVu lecture notes, converting only the introductory pages for preview, this approach efficiently handles several files in one run.
 * 4. When a cloud‑based microservice processes user‑submitted DjVu scans and must return a PDF containing specific pages while keeping memory usage under control, the example demonstrates the required C# workflow.
 * 5. When a desktop application offers a “Export selected pages” feature for DjVu comics, allowing users to choose page ranges and generate PDFs without exhausting system resources, the code provides the necessary implementation.
 */