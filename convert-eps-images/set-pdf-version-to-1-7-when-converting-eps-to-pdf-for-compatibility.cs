using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;   // PdfOptions, PdfCoreOptions, PdfComplianceVersion
using Aspose.Imaging.FileFormats.Eps;   // EpsImage

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options with the desired compliance (PDF 1.7 equivalent)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Aspose.Imaging currently supports Pdf15, PdfA1a, PdfA1b.
                    // Pdf15 corresponds to PDF 1.5, which is the closest available version.
                    PdfCompliance = PdfComplianceVersion.Pdf15
                }
            };

            // Save the EPS image as a PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}