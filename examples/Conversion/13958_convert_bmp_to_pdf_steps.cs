using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Input BMP file path
        string bmpPath = @"c:\temp\sample.bmp";

        // Desired output PDF file path
        string pdfPath = @"c:\temp\sample.pdf";

        // Load the BMP image using Aspose.Imaging
        using (Image image = Image.Load(bmpPath))
        {
            // Save the image as PDF. PdfOptions provides default settings for PDF export.
            image.Save(pdfPath, new PdfOptions());
        }
    }
}