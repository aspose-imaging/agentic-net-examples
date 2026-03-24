using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document and save as PDF
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
        {
            djvuImage.Save(outputPath, new PdfOptions());
        }
    }
}