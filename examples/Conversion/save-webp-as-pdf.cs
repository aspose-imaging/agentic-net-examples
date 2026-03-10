using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define the folder that contains the source WebP and the destination PDF.
        string dir = @"c:\temp\";

        // Load the WebP image from a file.
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Convert and save the image as a PDF document.
            // PdfOptions is used to specify the output format.
            webPImage.Save(dir + "output.pdf", new PdfOptions());
        }
    }
}