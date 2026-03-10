using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source 24‑bit BMP image
        string bmpPath = @"C:\temp\source.bmp";

        // Desired output PDF file path
        string pdfPath = @"C:\temp\result.pdf";

        // Load the BMP image using the standard Image.Load lifecycle method
        using (Image image = Image.Load(bmpPath))
        {
            // Convert and save the image to PDF using the standard Image.Save method
            image.Save(pdfPath, new PdfOptions());
        }
    }
}