using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Define the folder where the source WebP and the output PDF are located.
        string dir = @"c:\temp\";

        // Load the WebP image from file.
        using (WebPImage webPImage = new WebPImage(dir + "test.webp"))
        {
            // Save the loaded image as a PDF document.
            // PdfOptions specifies that the output format should be PDF.
            webPImage.Save(dir + "test.pdf", new PdfOptions());
        }
    }
}