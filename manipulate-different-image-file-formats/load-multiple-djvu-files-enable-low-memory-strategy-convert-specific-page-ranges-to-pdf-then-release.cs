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
        string[] inputPaths = new[]
        {
            @"C:\Data\Documents\sample1.djvu",
            @"C:\Data\Documents\sample2.djvu"
        };

        // Hard‑coded output PDF files (one per input)
        string[] outputPaths = new[]
        {
            @"C:\Data\Output\sample1.pdf",
            @"C:\Data\Output\sample2.pdf"
        };

        // Page numbers to convert (1‑based inclusive)
        int[] pagesToConvert = new[] { 1, 2, 3 };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Low‑memory load options (e.g., 1 MB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024
            };

            // Load DjVu document using a stream and low‑memory options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // If the DjVu file has more pages than requested, limit to the requested range
                // Create a new DjvuMultiPageOptions with the desired page indexes
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pagesToConvert);
                pdfOptions.MultiPageOptions = multiPageOptions;

                // Save the selected pages as a single PDF file
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}