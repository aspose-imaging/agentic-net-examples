using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;   // PdfCoreOptions
using Aspose.Imaging;                  // PdfComplianceVersion

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string inputImagePath = @"C:\Images\source.png";

        // Desired PDF output path
        string outputPdfPath = @"C:\Images\result.pdf";

        // Load the image using Aspose.Imaging's lifecycle rule
        using (Image image = Image.Load(inputImagePath))
        {
            // Create PDF export options
            var pdfOptions = new PdfOptions();

            // Set PDF compliance (e.g., PDF/A-1b) to ensure format compliance
            pdfOptions.PdfCoreOptions = new PdfCoreOptions
            {
                PdfCompliance = PdfComplianceVersion.PdfA1b
            };

            // Preserve image fidelity by using default compression (Auto)
            // If explicit compression is needed, uncomment and set:
            // pdfOptions.Compression = PdfImageCompressionOptions.Auto; // property exists in newer versions

            // Save the image as a PDF using the provided save rule
            image.Save(outputPdfPath, pdfOptions);
        }
    }
}