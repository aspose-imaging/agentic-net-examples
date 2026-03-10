using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConversion
{
    static void Main()
    {
        // Input PNG file path
        string pngPath = @"C:\temp\sample.png";

        // Desired output PDF file path
        string pdfPath = @"C:\temp\sample.pdf";

        // Load the PNG image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(pngPath))
        {
            // Create PDF export options (default settings are sufficient for a basic conversion)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF using the created options
            image.Save(pdfPath, pdfOptions);
        }
    }
}