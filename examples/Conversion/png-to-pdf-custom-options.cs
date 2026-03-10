using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path
        string inputPath = "input.png";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure custom PDF options
            var pdfOptions = new PdfOptions
            {
                // Use the original image resolution
                UseOriginalImageResolution = true,
                // Set page size (A4 in points: 595x842)
                PageSize = new Size(595, 842),
                // Set PDF core options, e.g., PDF/A-1b compliance
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the image as PDF with the custom options
            image.Save(outputPath, pdfOptions);
        }
    }
}