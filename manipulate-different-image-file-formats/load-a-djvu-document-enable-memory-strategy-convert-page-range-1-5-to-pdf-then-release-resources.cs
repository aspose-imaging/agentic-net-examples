using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set memory strategy via LoadOptions (e.g., limit buffer size)
            LoadOptions loadOptions = new LoadOptions
            {
                // Example: limit internal buffers to 10 MB
                BufferSizeHint = 10 * 1024 * 1024
            };

            // Load DjVu document with the specified load options
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(File.OpenRead(inputPath), loadOptions))
            {
                // Prepare PDF export options and specify pages 1‑5 (zero‑based indexes 0‑4)
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new MultiPageOptions
                    {
                        Pages = new int[] { 0, 1, 2, 3, 4 }
                    }
                };

                // Save the selected pages as a single PDF file
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
 * 1. When a developer needs to extract the first five pages of a multi‑page DjVu document and deliver them as a single PDF for easy viewing or printing.
 * 2. When an application processes large DjVu files on a server and must limit memory usage by setting a buffer size hint before converting selected pages to PDF.
 * 3. When a document management system must validate the existence of a DjVu source file, create the output folder, and then convert a specific page range to PDF for archival.
 * 4. When a C# batch‑processing tool automates the conversion of DjVu scans into PDF reports, handling pages 1‑5 while ensuring resources are released with a using block.
 * 5. When a developer integrates Aspose.Imaging into a workflow that reads DjVu streams, applies multi‑page PDF export options, and saves the result to a predefined directory.
 */