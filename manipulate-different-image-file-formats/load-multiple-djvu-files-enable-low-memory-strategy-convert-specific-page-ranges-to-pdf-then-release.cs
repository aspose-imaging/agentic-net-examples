// HOW-TO: Convert Selected DjVu Pages to PDF with Low Memory in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input DjVu files and corresponding output PDF files with page ranges
            var jobs = new[]
            {
                new
                {
                    InputPath = @"C:\Data\doc1.djvu",
                    OutputPath = @"C:\Data\doc1_selected.pdf",
                    // Pages 1 to 3 (inclusive)
                    PageRanges = new[] { new IntRange(1, 3) }
                },
                new
                {
                    InputPath = @"C:\Data\doc2.djvu",
                    OutputPath = @"C:\Data\doc2_selected.pdf",
                    // Pages 2,4,5 (non‑contiguous)
                    PageRanges = new[] { new IntRange(2, 2), new IntRange(4, 5) }
                }
            };

            foreach (var job in jobs)
            {
                // Verify input file exists
                if (!File.Exists(job.InputPath))
                {
                    Console.Error.WriteLine($"File not found: {job.InputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(job.OutputPath));

                // Configure low‑memory loading (e.g., 1 MB buffer)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024 // 1 MB
                };

                // Load DjVu document with the low‑memory options
                using (var stream = File.OpenRead(job.InputPath))
                using (var djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Prepare multi‑page options for the required page ranges
                    var multiPageOptions = new DjvuMultiPageOptions(job.PageRanges);

                    // Set up PDF saving options and attach the multi‑page options
                    var pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save selected pages as a PDF
                    djvuImage.Save(job.OutputPath, pdfOptions);
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
 * 1. When you need to extract only certain pages from large DjVu documents without loading the entire file into memory, this code lets you convert those pages to PDF efficiently.
 * 2. When processing a batch of scanned books stored as DjVu files on a server, you can use this approach to generate separate PDF files for specific chapters while keeping memory usage low.
 * 3. When building a document‑conversion service that must handle many DjVu uploads, the low‑memory loading ensures the service remains responsive even with high‑resolution files.
 * 4. When creating PDFs for legal or archival purposes that require only selected pages from multi‑page DjVu files, this code automates the extraction and conversion.
 * 5. When integrating DjVu to PDF conversion into a desktop application that runs on machines with limited RAM, the buffer‑size hint prevents out‑of‑memory errors while processing multiple files.
 */
