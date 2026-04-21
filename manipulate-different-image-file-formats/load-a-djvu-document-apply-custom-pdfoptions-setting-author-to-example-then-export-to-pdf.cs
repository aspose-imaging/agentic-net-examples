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
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Configure PDF options with custom author
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Example"
                }
            };

            // Export DjVu to PDF
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}