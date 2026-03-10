using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input BMP file path
        string bmpPath = @"c:\temp\sample.bmp";
        // Desired output PDF file path
        string pdfPath = @"c:\temp\sample.pdf";

        // Load the BMP image (lifecycle rule: use Image.Load)
        using (Image image = Image.Load(bmpPath))
        {
            // Create PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as PDF (lifecycle rule: use Image.Save)
            image.Save(pdfPath, pdfOptions);
        }
    }
}