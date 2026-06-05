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
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load EPS image and convert to PDF/A-1b
            using (var image = (EpsImage)Image.Load(inputPath))
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must archive vector graphics from legacy design tools by converting EPS files to PDF/A‑1b compliant PDFs for long‑term preservation.
 * 2. When a C# application needs to generate legally compliant PDF documents from EPS logos to meet government or industry standards that require PDF/A‑1b.
 * 3. When an automated build pipeline processes print‑ready EPS assets and must output PDF/A‑1b files to ensure they pass PDF validation before distribution.
 * 4. When a document management system imports EPS illustrations and must store them as PDF/A‑1b PDFs to guarantee consistent rendering across platforms.
 * 5. When a developer creates a batch conversion utility that reads EPS files from a folder and saves them as PDF/A‑1b PDFs using Aspose.Imaging’s PdfOptions and PdfCompliance enumeration.
 */