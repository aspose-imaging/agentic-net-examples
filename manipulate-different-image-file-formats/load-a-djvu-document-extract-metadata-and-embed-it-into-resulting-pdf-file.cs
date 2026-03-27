using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/result.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document from file stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = new Aspose.Imaging.FileFormats.Djvu.DjvuImage(stream))
            {
                // Extract metadata (XMP) from DjVu
                string metadata = djvuImage.Metadata?.ToString() ?? string.Empty;

                // Prepare PDF options and embed metadata
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    pdfOptions.PdfDocumentInfo.Title = metadata;

                    // Save DjVu as PDF with embedded metadata
                    djvuImage.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}