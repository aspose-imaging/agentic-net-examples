using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Define the folder where the source WebP and the resulting PDF will be stored.
        string dir = @"c:\temp\";

        // Load the WebP image from a file using the WebPImage constructor (load rule).
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Convert and save the loaded WebP image to PDF.
            // The Save method follows the save rule; PdfOptions specifies the target format.
            webPImage.Save(dir + "output.pdf", new PdfOptions());

            // Optionally, you can release resources earlier by calling Dispose(),
            // but the using statement will handle it automatically.
        }
    }
}