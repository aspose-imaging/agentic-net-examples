using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Load the EPS file into an EpsImage instance
        using (var epsImage = (EpsImage)Image.Load("input.eps"))
        {
            // Configure PDF saving options for high fidelity (PDF/A-1b compliance)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS image as a PDF document
            epsImage.Save("output.pdf", pdfOptions);
        }
    }
}