using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = {
                @"C:\Data\doc1.djvu",
                @"C:\Data\doc2.djvu"
            };

            string[] outputPaths = {
                @"C:\Data\Result\doc1.pdf",
                @"C:\Data\Result\doc2.pdf"
            };

            // Define page ranges to export (example: pages 1-3)
            int[] pagesToExport = { 1, 2, 3 };
            var multiPageOptions = new DjvuMultiPageOptions(pagesToExport);

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu with low‑memory strategy (1 MB buffer)
                var loadOptions = new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 };

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
 * 1. When a .NET application must batch‑convert large DjVu archives of scanned books into PDF while only extracting the first three chapters and keeping memory usage under 1 MB per file.
 * 2. When a document‑management system needs to process user‑uploaded DjVu files on a server with limited RAM, converting selected pages to searchable PDF for downstream indexing.
 * 3. When a legal‑tech solution has to generate PDF excerpts from multiple DjVu case files, preserving only the relevant pages to reduce storage and improve download speed.
 * 4. When an e‑learning platform automates the creation of PDF handouts from DjVu lecture notes, selecting specific slides and ensuring the conversion runs on low‑memory cloud instances.
 * 5. When a desktop utility built with C# and Aspose.Imaging must load several DjVu documents, apply a low‑memory buffer, export defined page ranges to PDF, and then release resources to avoid memory leaks.
 */