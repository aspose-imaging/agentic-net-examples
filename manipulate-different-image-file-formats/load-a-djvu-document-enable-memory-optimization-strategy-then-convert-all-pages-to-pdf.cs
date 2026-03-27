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
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure load options to limit internal buffer size (memory optimization)
        LoadOptions loadOptions = new LoadOptions
        {
            BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
        };

        // Load the DjVu document with the specified load options
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
        {
            // Convert the entire DjVu document (all pages) to a single PDF file
            djvuImage.Save(outputPath, new PdfOptions());
        }
    }
}