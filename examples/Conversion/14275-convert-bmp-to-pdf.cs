using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = "input.bmp";

        // Desired output PDF file path
        string pdfPath = "output.pdf";

        // Load the BMP image using Aspose.Imaging's Image.Load method
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Create PDF save options (default settings are sufficient for a simple conversion)
            var pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            bmpImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed: BMP -> PDF");
    }
}