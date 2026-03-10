using System;
using System.IO;
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
        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            // Create PDF options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the loaded image as a PDF
                jpgImage.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}