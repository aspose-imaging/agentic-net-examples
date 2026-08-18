// HOW-TO: Convert DjVu Document To Multi‑Page PDF With Memory Optimization In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure memory optimization (buffer size hint)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Load DjVu image with the specified load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Set up PDF save options to export all pages
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions() // export all pages
                };

                // Save the DjVu document as a PDF
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
 * 1. When you need to transform a multi‑page DjVu file into a single PDF for easier distribution while keeping memory usage low.
 * 2. When processing large DjVu archives on a server and want to limit RAM consumption by specifying a buffer size.
 * 3. When integrating document conversion into a .NET application that must support both DjVu input and PDF output.
 * 4. When automating batch conversion of scanned books stored as DjVu into searchable PDF files.
 * 5. When preparing DjVu‑based technical manuals for printing or archiving in PDF format without loading the entire document into memory.
 */
