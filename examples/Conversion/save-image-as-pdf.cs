using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Input image file (any supported format)
        string inputPath = @"C:\temp\sample.jpg";

        // Desired PDF output file
        string outputPath = @"C:\temp\sample.pdf";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Example: set PDF compliance or compression if required
            // pdfOptions.PdfCoreOptions = new PdfCoreOptions
            // {
            //     PdfCompliance = PdfComplianceVersion.PdfA1b,
            //     Compression = PdfImageCompressionOptions.Flate
            // };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}