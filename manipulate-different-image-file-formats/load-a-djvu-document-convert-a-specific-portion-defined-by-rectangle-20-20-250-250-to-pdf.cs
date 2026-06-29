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
            string inputPath = "input.djvu";
            string outputPath = "output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare PDF export options with specific page and rectangle area
                PdfOptions pdfOptions = new PdfOptions();

                // Define export rectangle (x, y, width, height)
                Rectangle exportArea = new Rectangle(20, 20, 250, 250);

                // Export only the first page (index 0) with the defined area
                int[] pages = new int[] { 0 };
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(pages, exportArea);

                // Save the selected portion to PDF
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
 * 1. When a developer needs to extract a specific region of a scanned DjVu page (e.g., a signature block) and embed it into a PDF report.
 * 2. When an application must generate a PDF preview of a selected area from a multi‑page DjVu document for faster loading in a web viewer.
 * 3. When a document management system requires converting only the first page’s defined rectangle of a DjVu file to PDF to reduce file size.
 * 4. When a legal tech solution needs to isolate a portion of a DjVu blueprint (coordinates 20,20,250,250) and save it as a PDF for client review.
 * 5. When an automated batch process must read DjVu files, crop a fixed rectangle, and output PDFs for archival compliance.
 */