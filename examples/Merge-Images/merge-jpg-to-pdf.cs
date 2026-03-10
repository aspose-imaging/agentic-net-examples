using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to be merged into a PDF
        string[] jpgFiles = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Output PDF file path
        string outputPdf = "merged.pdf";

        // Create a multipage image from the JPEG files
        using (Image pdfImage = Image.Create(jpgFiles))
        {
            // Configure PDF options (default settings)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            pdfImage.Save(outputPdf, pdfOptions);
        }
    }
}