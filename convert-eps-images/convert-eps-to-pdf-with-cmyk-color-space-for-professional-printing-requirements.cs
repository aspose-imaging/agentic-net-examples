using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image and convert it to PDF with PDF/A-1b compliance (suitable for professional printing)
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // PDF/A-1b compliance enforces CMYK color space for printing
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the converted PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}