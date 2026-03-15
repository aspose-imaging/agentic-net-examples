using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BMP image
        string bmpPath = @"C:\Images\source.bmp";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\output.pdf";

        // Load the BMP image using the provided Image.Load method
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Save the loaded image as a PDF document.
            // PdfOptions ensures the image is embedded as a single page with original fidelity.
            bmpImage.Save(pdfPath, new PdfOptions());
        }
    }
}