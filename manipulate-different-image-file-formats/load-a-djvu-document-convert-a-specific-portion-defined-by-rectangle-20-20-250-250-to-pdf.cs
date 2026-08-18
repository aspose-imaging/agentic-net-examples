// HOW-TO: Extract a Rectangular Region from DjVu and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.djvu";
            string outputPath = "output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define export rectangle (x, y, width, height)
                Aspose.Imaging.Rectangle exportArea = new Aspose.Imaging.Rectangle(20, 20, 250, 250);

                // Set up PDF save options with page index 0 and export area
                var pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(0, exportArea)
                };

                // Save the specified portion to PDF
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
 * 1. When you need to embed only a specific part of a scanned DjVu page into a PDF report.
 * 2. When you want to programmatically generate PDF thumbnails from selected areas of DjVu documents.
 * 3. When you must extract a region of a DjVu blueprint to share with collaborators in PDF format.
 * 4. When you are building a document conversion service that converts user‑selected DjVu sections to PDF for easier viewing.
 * 5. When you need to automate the creation of PDF excerpts from large DjVu files for archival or compliance purposes.
 */
