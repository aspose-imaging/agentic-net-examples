using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = @"C:\Images\source.bmp";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\converted.pdf";

        // Load the BMP image
        using (Image image = Image.Load(bmpPath))
        {
            // Create PDF export options
            var pdfOptions = new PdfOptions();

            // (Optional) Set PDF compliance if required
            // pdfOptions.PdfCoreOptions = new PdfCoreOptions
            // {
            //     PdfCompliance = PdfComplianceVersion.PdfA1b
            // };

            // Save the image as a PDF document
            image.Save(pdfPath, pdfOptions);
        }
    }
}