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

        // Configure load options with a memory buffer hint
        var loadOptions = new LoadOptions
        {
            BufferSizeHint = 10 * 1024 * 1024 // 10 MB buffer
        };

        // Load the DjVu document using the configured load options
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
        {
            // Define the page range 1‑5
            var pageRange = new IntRange(1, 5);
            var multiPageOptions = new DjvuMultiPageOptions(pageRange);

            // Set PDF options and attach the multi‑page options
            var pdfOptions = new PdfOptions
            {
                MultiPageOptions = multiPageOptions
            };

            // Save the selected pages as a PDF
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}