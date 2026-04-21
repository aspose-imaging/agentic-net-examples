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
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with PDF/A compliance (PDF 1.7 compatible)
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b // PDF/A-1b is based on PDF 1.7
                };

                // Save the SVG as PDF with embedded fonts
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}