using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string inputPath = "input.eps";
        // Desired output PDF file path
        string outputPath = "output.pdf";

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific EPS image type
            var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
            if (epsImage == null)
                throw new InvalidOperationException("The provided file is not a valid EPS image.");

            // Configure PDF options with high‑fidelity compliance (PDF/A‑1b as an example)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as a PDF document
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}