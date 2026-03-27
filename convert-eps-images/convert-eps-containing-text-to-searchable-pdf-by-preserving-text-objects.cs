using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EPS image and convert to searchable PDF
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Use PDF/A-1b compliance for searchable PDF
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save as PDF preserving text objects
            image.Save(outputPath, pdfOptions);
        }
    }
}