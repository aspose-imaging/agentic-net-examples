using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input BMP and output PDF
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Configure PDF export options
        using (PdfOptions pdfOptions = new PdfOptions())
        {
            // Preserve original metadata
            pdfOptions.KeepMetadata = true;
            // Ensure full frame is used
            pdfOptions.FullFrame = true;
            // Set page size (e.g., A4 size in points)
            pdfOptions.PageSize = new Size(595, 842);
            // Define PDF compliance version
            pdfOptions.PdfCoreOptions = new PdfCoreOptions
            {
                PdfCompliance = PdfComplianceVersion.PdfA1b
            };

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PDF with the custom options
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}