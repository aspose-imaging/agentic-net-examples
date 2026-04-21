using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and convert to PDF with PDF/A-1b compliance
        using (Image image = Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            image.Save(outputPath, pdfOptions);
        }
    }
}