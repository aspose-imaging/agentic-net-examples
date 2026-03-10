using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP image
        string inputBmpPath = @"c:\temp\sample.bmp";

        // Desired output PDF file path
        string outputPdfPath = @"c:\temp\sample.pdf";

        // Load the BMP image using the provided load rule
        using (Image image = Image.Load(inputBmpPath))
        {
            // Save the loaded image as PDF.
            // Since there is no specific rule for PDF conversion, we use the generic Save method with PdfOptions.
            image.Save(outputPdfPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed: " + outputPdfPath);
    }
}