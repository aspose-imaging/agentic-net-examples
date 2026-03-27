using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Input and output paths
        string inputPath = "Input\\sample.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "Output\\output.pdf";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu image
        using (Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)Image.Load(inputPath))
        {
            // Configure PDF options with author metadata
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

                // Export all pages
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save as PDF
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}