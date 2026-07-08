using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input DjVu file path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hard‑coded output directory for the generated PDFs
            string outputDir = @"C:\Temp\PdfOutput";

            // Load the DjVu document with a memory‑optimisation hint (1 MB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Iterate through all pages and save each as an individual PDF file
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build the output file name (e.g., page_1.pdf, page_2.pdf, …)
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as PDF
                    page.Save(outputPath, new PdfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a multi‑page DjVu archive of scanned documents into individual PDF files while keeping memory usage low.
 * 2. When an application must extract each page of a large DjVu file (e.g., a digitized book) and store them as separate PDF pages for downstream processing or printing.
 * 3. When a server‑side service processes user‑uploaded DjVu files and must generate PDF versions on‑the‑fly without exhausting RAM.
 * 4. When a document‑management system needs to preserve the original page layout of DjVu scans by converting each page to PDF for archival compliance.
 * 5. When a .NET utility has to verify the existence of a DjVu file, create an output folder, and reliably save each page as a PDF using Aspose.Imaging’s memory‑optimised loading.
 */