// HOW-TO: Convert EPS to PDF/A‑1b Compliant PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Set PDF/A-1b compliance options
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF with the specified compliance
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to archive vector graphics from EPS files in a PDF/A‑1b format for long‑term preservation or regulatory compliance.
 * 2. When a printing workflow requires converting EPS artwork to PDF while guaranteeing PDF/A‑1b conformance for automated document management systems.
 * 3. When a web service generates PDF reports from EPS logos and must ensure the output meets ISO‑19005‑1 standards for accessibility and archival.
 * 4. When integrating Aspose.Imaging into a C# application to batch‑process EPS files into PDF/A‑1b PDFs for a digital asset management repository.
 * 5. When a client mandates that all exported PDFs from design files be PDF/A‑1b compliant, and you need a simple C# code snippet to enforce that during conversion.
 */
