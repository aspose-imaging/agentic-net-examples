using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Path to the source image (any format supported by Aspose.Imaging)
        string inputPath = "input.png";

        // Desired output PDF file path
        string outputPath = "output.pdf";

        // Load the source image using Aspose.Imaging's load mechanism
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options
            var pdfOptions = new PdfOptions();

            // Set PDF core options to enforce a specific PDF compliance level
            pdfOptions.PdfCoreOptions = new PdfCoreOptions
            {
                // Choose the required compliance (e.g., PDF/A-1b for archival purposes)
                PdfCompliance = PdfComplianceVersion.PdfA1b
            };

            // Save the loaded image as a PDF file with the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}