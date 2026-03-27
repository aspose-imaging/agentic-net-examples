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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = Path.Combine(
            @"C:\Images\Converted",
            Path.GetFileNameWithoutExtension(inputPath) + "_converted.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options (optional compliance setting)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Example compliance; adjust as needed
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save as PDF using the custom output path
            image.Save(outputPath, pdfOptions);
        }
    }
}