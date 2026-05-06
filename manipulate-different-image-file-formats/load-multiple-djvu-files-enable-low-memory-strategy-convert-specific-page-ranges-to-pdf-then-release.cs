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
            // Hard‑coded input DjVu files
            string[] inputPaths = {
                @"C:\Data\doc1.djvu",
                @"C:\Data\doc2.djvu"
            };

            // Corresponding output PDF files
            string[] outputPaths = {
                @"C:\Data\Result\doc1.pdf",
                @"C:\Data\Result\doc2.pdf"
            };

            // Page indexes to export for each file (0‑based)
            int[][] pagesToExport = {
                new int[] { 0, 1, 2 },   // first three pages of doc1.djvu
                new int[] { 4, 5 }       // pages 5 and 6 of doc2.djvu
            };

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
                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                // Low‑memory loading options (e.g., 1 MB buffer)
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024
                };

                // Open the DjVu document with the low‑memory options
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
                {
                    // Define which pages to export
                    DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pagesToExport[i]);

                    // Set up PDF saving options with the selected pages
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save selected pages as a PDF
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