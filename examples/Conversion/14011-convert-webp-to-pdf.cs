using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Define the folder that contains the source WebP file and the output PDF file.
        string dir = @"c:\temp\";

        // Load the WebP image from the file system using the WebPImage constructor (load rule).
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Save the loaded image as a PDF document.
            // The Save method follows the generic save rule; PdfOptions specifies the target format.
            webPImage.Save(dir + "output.pdf", new PdfOptions());
        }
    }
}