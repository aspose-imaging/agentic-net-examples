using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP image
        string bmpFilePath = @"C:\Images\sample.bmp";

        // Desired output PDF file path
        string pdfFilePath = @"C:\Images\sample.pdf";

        // Load the BMP image using Aspose.Imaging's lifecycle rule
        using (Image image = Image.Load(bmpFilePath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Optional: preserve original DPI resolution
            pdfOptions.UseOriginalImageResolution = true;

            // Save the loaded image as a PDF document using the Save(string, ImageOptionsBase) rule
            image.Save(pdfFilePath, pdfOptions);
        }

        Console.WriteLine("BMP image successfully converted to PDF.");
    }
}