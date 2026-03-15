using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input PNG and output PDF file paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Set page size (A4 in points)
                pdfOptions.PageSize = new Size(595, 842);

                // Preserve original image metadata
                pdfOptions.KeepMetadata = true;

                // Set PDF/A-1b compliance
                pdfOptions.PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                };

                // Add basic document information
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Converted PDF",
                    Author = "Aspose.Imaging"
                };

                // Save the image as a PDF using the custom options
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}