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
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputPath = "output\\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Enable memory strategy via LoadOptions (e.g., limit buffer size)
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024 // 1 MB
                };

                // Load DjVu document with the specified load options
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Define page range 1‑5 (pages are 1‑based)
                    int[] pages = new int[] { 1, 2, 3, 4, 5 };
                    DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pages);

                    // Set up PDF saving options with the page range
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save selected pages to PDF
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
 * 1. When a document management system needs to extract the first five pages of a large DjVu archive and store them as a lightweight PDF for quick preview, developers can use this code to load the DjVu with a memory‑saving buffer and save the selected pages.
 * 2. When an e‑learning platform wants to convert a DjVu textbook’s introductory chapters (pages 1‑5) into PDF format for offline reading on mobile devices, this snippet demonstrates how to limit memory usage while performing the conversion in C#.
 * 3. When a legal firm processes scanned case files stored as DjVu and must generate a PDF docket containing only the initial pages for client review, the example shows how to specify a page range and release resources safely.
 * 4. When a batch‑processing tool needs to automate the conversion of multiple DjVu files to PDFs but must avoid high RAM consumption, developers can apply the shown LoadOptions buffer hint and multi‑page PDF options to handle each file efficiently.
 * 5. When a content‑migration script migrates legacy DjVu manuals to PDF and only the first five pages are required for a summary report, this code provides a straightforward way to load, convert, and clean up the image resources in .NET.
 */