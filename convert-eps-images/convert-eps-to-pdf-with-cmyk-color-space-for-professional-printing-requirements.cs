using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;          // EpsImage
using Aspose.Imaging.ImageOptions;           // PdfOptions
using Aspose.Imaging.FileFormats.Pdf;        // PdfCoreOptions, PdfComplianceVersion

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the EPS source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image and convert it to PDF with PDF/A‑1b compliance
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // PDF/A‑1b is a common CMYK‑compatible compliance for professional printing
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS as a PDF file
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}