using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.djvu";
        string outputPath = @"C:\Data\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Configure memory strategy (buffer size hint)
            LoadOptions loadOptions = new LoadOptions
            {
                // Example: limit internal buffers to 5 MB
                BufferSizeHint = 5 * 1024 * 1024
            };

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu document with the specified load options
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    // Define page range 1‑5 (zero‑based indexes 0‑4)
                    int[] pages = new int[] { 0, 1, 2, 3, 4 };
                    DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pages);

                    // Set up PDF saving options with the page range
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save selected pages as a single PDF file
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