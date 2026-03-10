using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class ConvertWebPToPdf
{
    static void Main()
    {
        // Path to the folder containing the source WebP image.
        string dir = @"c:\temp\";

        // Load the high‑quality WebP image from file.
        // This uses the documented constructor for WebPImage(string).
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Prepare PDF save options.  Aspose.Imaging can render raster images to PDF.
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded WebP image as a PDF document.
            // The Save method with (string, ImageOptionsBase) follows the documented save pattern.
            webPImage.Save(dir + "output.pdf", pdfOptions);
        }
    }
}