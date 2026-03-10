using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class ConvertWebPToPdf
{
    static void Main()
    {
        // Path to the source lossless WebP image
        string sourcePath = @"C:\temp\input.webp";

        // Path where the resulting PDF will be saved
        string pdfPath = @"C:\temp\output.pdf";

        // Load the WebP image using the WebPImage constructor (load rule)
        using (WebPImage webPImage = new WebPImage(sourcePath))
        {
            // Save the image as PDF using the generic Save method with PdfOptions (save rule)
            webPImage.Save(pdfPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}