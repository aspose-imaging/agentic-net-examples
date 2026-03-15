using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Input BMP file path
        string bmpPath = @"C:\temp\sample.bmp";

        // Desired PDF output path
        string pdfPath = @"C:\temp\sample.pdf";

        // Load the BMP image using Aspose.Imaging's Load method
        using (Image image = Image.Load(bmpPath))
        {
            // Save the loaded image as PDF using default PDF options
            image.Save(pdfPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed: " + pdfPath);
    }
}