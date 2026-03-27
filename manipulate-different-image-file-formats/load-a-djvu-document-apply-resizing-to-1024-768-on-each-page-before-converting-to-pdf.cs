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
        string inputPath = "input.djvu";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(stream))
        {
            // Resize the entire document to 1024x768 (applies to all pages)
            djvuImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Save the resized document as PDF
            PdfOptions pdfOptions = new PdfOptions();
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}