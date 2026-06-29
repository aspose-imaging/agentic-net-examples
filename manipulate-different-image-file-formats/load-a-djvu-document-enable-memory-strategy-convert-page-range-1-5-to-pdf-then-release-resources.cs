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
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document with memory strategy (buffer size hint)
            LoadOptions loadOptions = new LoadOptions
            {
                // Example: limit internal buffers to 2 MB
                BufferSizeHint = 2 * 1024 * 1024
            };

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Define page range 1‑5 (Aspose uses 1‑based indexing for DjvuMultiPageOptions)
                int[] pages = new int[] { 1, 2, 3, 4, 5 };
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pages);

                // Set up PDF save options with the page range
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = multiPageOptions
                };

                // Save selected pages as PDF
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
 * 1. When a developer needs to extract the first five pages of a large DjVu document and convert them to a PDF while controlling memory usage with a buffer size hint.
 * 2. When an application must verify the existence of a DjVu file, create the output directory, and safely load the document using Aspose.Imaging's LoadOptions to prevent out‑of‑memory errors.
 * 3. When a batch conversion tool processes multiple DjVu files and only a specific page range (pages 1‑5) should be included in the resulting PDF for compliance or preview purposes.
 * 4. When integrating DjVu‑to‑PDF conversion into a C# workflow that requires explicit disposal of streams and image objects to release unmanaged resources promptly.
 * 5. When a developer wants to use Aspose.Imaging's DjvuMultiPageOptions and PdfOptions to customize multi‑page PDF output from a DjVu source in a .NET environment.
 */