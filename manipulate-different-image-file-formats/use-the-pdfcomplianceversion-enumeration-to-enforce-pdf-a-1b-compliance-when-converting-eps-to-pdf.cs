using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image and cast to EpsImage
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with PDF/A-1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF with the specified options
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
 * 1. When a publishing system needs to archive vector graphics from EPS files as PDF/A‑1b compliant PDFs for long‑term preservation and legal compliance.
 * 2. When an e‑learning platform converts EPS diagrams to PDF/A‑1b PDFs to ensure the content remains viewable across all PDF readers without loss of fidelity.
 * 3. When a government agency automates the transformation of EPS engineering drawings into PDF/A‑1b PDFs to meet mandatory document‑management standards.
 * 4. When a print‑on‑demand service generates PDF/A‑1b PDFs from EPS logos to guarantee color accuracy and reproducibility for high‑volume printing.
 * 5. When a document‑generation workflow integrates Aspose.Imaging in C# to convert EPS assets to PDF/A‑1b PDFs, satisfying ISO 19005‑1 compliance for audited reports.
 */