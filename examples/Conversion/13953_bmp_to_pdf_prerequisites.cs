using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class BmpToPdfConverter
{
    static void Main()
    {
        // Prerequisite 1: Ensure Aspose.Imaging license is set (optional but required for production use)
        // var license = new Aspose.Imaging.License();
        // license.SetLicense("Aspose.Imaging.lic");

        // Prerequisite 2: Input BMP file must exist and be accessible
        string bmpPath = @"C:\Images\sample.bmp";

        // Prerequisite 3: Output directory must be writable
        string pdfPath = @"C:\Images\sample.pdf";

        // Load the BMP image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Create PDF export options
            var pdfOptions = new PdfOptions
            {
                // Optional: set PDF compliance version if a specific PDF/A standard is required
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the image as PDF using the Save method (lifecycle rule)
            bmpImage.Save(pdfPath, pdfOptions);
        }
    }
}