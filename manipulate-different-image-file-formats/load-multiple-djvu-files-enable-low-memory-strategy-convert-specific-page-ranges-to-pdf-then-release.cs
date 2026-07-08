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
            string[] inputFiles = new string[]
            {
                @"C:\Data\doc1.djvu",
                @"C:\Data\doc2.djvu"
            };

            // Pages to include in the PDF (example: pages 1, 2, 3)
            int[] pagesToConvert = new int[] { 1, 2, 3 };

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure low‑memory loading (1 MB buffer)
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024
                };

                // Load DjVu document with the specified load options
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Define page range options for the conversion
                    DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pagesToConvert);

                    // Set up PDF saving options with the selected pages
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save selected pages as a PDF file
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
 * 1. When a document‑management system must batch‑process large DjVu archives on a server with limited RAM, a developer can use this code to load each file with a 1 MB buffer, extract only the required pages, and save them as PDF.
 * 2. When an e‑learning platform needs to generate printable PDFs from selected pages of scanned lecture notes stored as DjVu files, this snippet lets a C# service load the files efficiently and output the chosen pages as a PDF.
 * 3. When a legal‑tech application has to convert specific pages of multiple multi‑page DjVu contracts into PDF for client review while avoiding out‑of‑memory errors, the low‑memory loading and page‑range options in this code are ideal.
 * 4. When a desktop utility must allow users to pick a few pages from several DjVu manuals and combine them into separate PDF files without consuming much memory, a developer can implement the shown approach.
 * 5. When an automated archival workflow needs to extract only the cover and index pages from many DjVu documents and store them as PDFs on a low‑resource build server, this code provides the necessary page‑selection and memory‑efficient loading.
 */