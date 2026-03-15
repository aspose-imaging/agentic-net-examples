using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = @"C:\Images\source.bmp";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\result.pdf";

        // Load the BMP image using Aspose.Imaging's Load method
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Create PDF save options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            bmpImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}