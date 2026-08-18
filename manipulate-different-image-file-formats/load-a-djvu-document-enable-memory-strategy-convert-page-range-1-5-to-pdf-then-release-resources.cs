// HOW-TO: Convert Specific DjVu Pages To PDF With Memory Buffer In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.djvu";
        string outputPath = "output.pdf";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Configure memory strategy (buffer size hint)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Open the DjVu file stream and load the document with the specified options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Define the page range to convert (pages 1‑5)
                int[] pagesToConvert = new int[] { 1, 2, 3, 4, 5 };
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pagesToConvert);

                // Set up PDF saving options with the selected page range
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = multiPageOptions
                };

                // Save the selected pages as a PDF file
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
 * 1. When you need to extract the first few pages of a large DjVu document and generate a smaller PDF for preview or sharing.
 * 2. When you want to limit memory usage while loading a DjVu file by providing a buffer size hint in a .NET application.
 * 3. When you have to programmatically convert a range of DjVu pages (e.g., pages 1‑5) into a PDF for batch processing or archiving.
 * 4. When you need to ensure the output directory exists and handle missing input files gracefully before converting DjVu to PDF.
 * 5. When you want to automatically release file streams and image resources after saving a DjVu document as PDF in C#.
 */
