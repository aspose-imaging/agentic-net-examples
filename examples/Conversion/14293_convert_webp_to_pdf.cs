using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Folder containing the source WebP image and the destination PDF.
        string dir = @"c:\temp\";

        // Load the WebP image from file.
        using (WebPImage webPImage = new WebPImage(dir + "test.webp"))
        {
            // Save the loaded image as a PDF document.
            // PdfOptions specifies the output format; only the active frame is saved.
            webPImage.Save(dir + "test.pdf", new PdfOptions());
        }
    }
}