using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Expect input BMP path and output PDF path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <exe> <inputBmpPath> <outputPdfPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to preserve metadata
            PdfOptions pdfOptions = new PdfOptions
            {
                KeepMetadata = true,
                PdfDocumentInfo = new PdfDocumentInfo()
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}