using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.djvu");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load DjVu image
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Configure PDF options with author metadata
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
            pdfOptions.PdfDocumentInfo.Author = "Custom Author";

            // Export all pages to PDF
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}