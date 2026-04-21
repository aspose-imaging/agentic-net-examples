using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded input EPS file path
        string inputPath = @"C:\Images\Sample.eps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Build a custom output file name based on the input name
        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_converted.pdf";
        string outputPath = Path.Combine(@"C:\Images\Output", outputFileName);

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options (example: set PDF/A‑1b compliance)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as PDF using the custom output path
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine($"Conversion completed: {outputPath}");
    }
}