using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Path to the source lossless WebP image
        string inputPath = @"C:\Temp\source_lossless.webp";

        // Desired output PDF file path
        string outputPath = @"C:\Temp\converted.pdf";

        // Load the WebP image using the provided constructor (load rule)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the image as PDF while preserving original fidelity.
            // The Save method with ImageOptionsBase follows the prescribed save rule.
            webPImage.Save(outputPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}