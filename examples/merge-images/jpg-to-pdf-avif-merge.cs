using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

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
            // Create PDF options (no source needed for saving)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            image.Save(outputPdfPath, pdfOptions);
        }

        // Note: AVIF format is not supported for saving in Aspose.Imaging.
        // If AVIF support is required, an exception should be thrown or a fallback used.
        // Here we perform a direct JPG to PDF conversion as per the available workflow.
    }
}