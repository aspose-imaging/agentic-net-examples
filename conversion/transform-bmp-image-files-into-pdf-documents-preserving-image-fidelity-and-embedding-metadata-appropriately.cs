using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            var pdfOptions = new PdfOptions
            {
                // Preserve original metadata in the PDF
                KeepMetadata = true
                // Additional metadata (e.g., PdfDocumentInfo) can be set here if required
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}