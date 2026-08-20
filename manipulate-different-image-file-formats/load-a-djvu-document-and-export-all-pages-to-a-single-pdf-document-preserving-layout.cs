// HOW-TO: Convert Multi‑Page DjVu to Single PDF in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare PDF save options with multi‑page export
                var pdfOptions = new PdfOptions
                {
                    // Export all pages; an empty DjvuMultiPageOptions means all pages
                    MultiPageOptions = new DjvuMultiPageOptions()
                };

                // Save all pages into a single PDF file
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
 * 1. When you need to archive scanned documents originally saved as DjVu by converting them into a universally viewable PDF file.
 * 2. When a web application must merge all pages of a DjVu e‑book into one PDF for easier distribution to users.
 * 3. When an automated batch process has to transform DjVu reports into PDF format for compliance and printing workflows.
 * 4. When a desktop utility needs to preserve the original layout while converting multi‑page DjVu diagrams into a single PDF for sharing with non‑technical stakeholders.
 * 5. When a document management system requires importing DjVu files and storing them as searchable PDFs without losing page order.
 */
