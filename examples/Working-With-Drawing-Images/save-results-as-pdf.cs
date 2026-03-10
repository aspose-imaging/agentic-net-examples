using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class PdfConversionExample
{
    static void Main()
    {
        // Input image path (any supported format)
        string inputPath = @"C:\Images\sample.png";

        // Output PDF path
        string outputPath = @"C:\Images\sample.pdf";

        // Load the source image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options using the provided PdfOptions constructor
            var pdfOptions = new PdfOptions
            {
                // Optional: set PDF compliance level via PdfCoreOptions
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b // Example compliance
                }
            };

            // Save the image as PDF using the provided save rule
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("Image successfully saved as PDF to: " + outputPath);
    }
}