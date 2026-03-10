using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input BMP file path
        string bmpPath = @"C:\temp\sample.bmp";
        // Desired output PDF file path
        string pdfPath = @"C:\temp\output.pdf";

        // Load the BMP image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(bmpPath))
        {
            // Save the image as a PDF document using PdfOptions
            image.Save(pdfPath, new PdfOptions());
        }
    }
}