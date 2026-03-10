using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageOptions.Pdf;

class Program
{
    static void Main()
    {
        // Input EPS file path
        string epsPath = "input.eps";

        // Output PDF file path
        string pdfPath = "output.pdf";

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(epsPath))
        {
            // Configure PDF saving options (optional: set PDF/A compliance)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS image as a PDF document
            epsImage.Save(pdfPath, pdfOptions);
        }
    }
}