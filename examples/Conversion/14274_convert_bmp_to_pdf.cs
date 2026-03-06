using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = @"c:\temp\sample.bmp";

        // Desired output PDF file path
        string pdfPath = @"c:\temp\output.pdf";

        // Load the BMP image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(bmpPath))
        {
            // Save the loaded image as PDF. PdfOptions provides default settings for PDF export.
            image.Save(pdfPath, new PdfOptions());
        }
    }
}