using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input DjVu files
        string[] inputPaths = {
            @"C:\Data\sample1.djvu",
            @"C:\Data\sample2.djvu"
        };

        // Corresponding output PDF files
        string[] outputPaths = {
            @"C:\Data\sample1.pdf",
            @"C:\Data\sample2.pdf"
        };

        // Page indexes to export for each file (1‑based as required by Aspose)
        int[][] pagesToExport = {
            new int[] { 1, 2, 3 },   // pages for sample1.djvu
            new int[] { 2, 4 }       // pages for sample2.djvu
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Low‑memory loading options (e.g., 1 MB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024
            };

            // Load DjVu document with the low‑memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Define which pages to export
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pagesToExport[i]);

                // Prepare PDF saving options and attach the page selection
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = multiPageOptions
                };

                // Save selected pages as a single PDF file
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}