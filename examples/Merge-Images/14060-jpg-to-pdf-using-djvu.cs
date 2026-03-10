using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string inputJpgPath = "input.jpg";
        // Output PDF file path
        string outputPdfPath = "output.pdf";

        // Load the JPG image
        using (Image image = Image.Load(inputJpgPath))
        {
            // Create PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image as a PDF
            image.Save(outputPdfPath, pdfOptions);
        }
    }
}