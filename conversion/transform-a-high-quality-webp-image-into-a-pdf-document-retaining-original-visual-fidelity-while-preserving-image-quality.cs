using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source WebP image
        string inputPath = @"c:\temp\input.webp";
        // Desired output PDF file path
        string outputPath = @"c:\temp\output.pdf";

        // Load the WebP image using the provided constructor
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the image as a PDF while preserving its original quality
            webPImage.Save(outputPath, new PdfOptions());
        }
    }
}