using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source GIF file
        string gifPath = @"C:\Temp\sample.gif";

        // Desired output PDF file path
        string pdfPath = @"C:\Temp\sample.pdf";

        // Load the GIF image using Aspose.Imaging's load method
        using (Image gifImage = Image.Load(gifPath))
        {
            // Create default PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the GIF image as a PDF document
            gifImage.Save(pdfPath, pdfOptions);
        }
    }
}