using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Configure PDF options with the desired compliance (PDF 1.7 equivalent)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Aspose.Imaging does not expose a direct PDF 1.7 enum;
                    // Pdf15 is the closest available compliance level.
                    PdfCompliance = PdfComplianceVersion.Pdf15
                }
            };

            // Save as PDF
            cdrImage.Save(outputPath, pdfOptions);
        }
    }
}