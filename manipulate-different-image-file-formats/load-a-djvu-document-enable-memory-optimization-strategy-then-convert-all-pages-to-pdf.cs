using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "Output/output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set memory optimization options
        var loadOptions = new LoadOptions
        {
            BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
        };

        // Load DjVu document with memory optimization
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
        {
            // Convert all pages to PDF
            var pdfOptions = new PdfOptions();
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}