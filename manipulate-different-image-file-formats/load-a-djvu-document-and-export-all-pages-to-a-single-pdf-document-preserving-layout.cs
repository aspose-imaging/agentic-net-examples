using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare PDF saving options (multi‑page export is handled automatically)
            PdfOptions pdfOptions = new PdfOptions();

            // Export all pages to a single PDF file preserving layout
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}