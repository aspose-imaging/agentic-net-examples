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
            // Create PDF save options – this tells Aspose.Imaging to render the image as a PDF document
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image to PDF using the Save method that accepts a file name and options
            bmpImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine($"BMP image has been successfully converted to PDF: {pdfPath}");
    }
}