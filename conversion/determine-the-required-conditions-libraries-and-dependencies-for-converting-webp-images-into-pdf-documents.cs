using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.webp";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image and save it as PDF
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // PDF options can be customized if needed
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image to PDF
            webPImage.Save(outputPath, pdfOptions);
        }
    }
}