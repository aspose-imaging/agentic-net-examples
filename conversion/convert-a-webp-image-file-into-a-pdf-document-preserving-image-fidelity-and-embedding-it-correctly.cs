using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Path to the source WebP image
        string inputPath = @"C:\temp\input.webp";

        // Desired output PDF file path
        string outputPath = @"C:\temp\output.pdf";

        // Load the WebP image using the constructor that accepts a file path
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the loaded image as a PDF document.
            // PdfOptions ensures the image is embedded with full fidelity.
            webPImage.Save(outputPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}