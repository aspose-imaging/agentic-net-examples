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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with PDF/A-1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as PDF
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
 * 1. When a publishing workflow requires converting legacy EPS artwork to PDF/A‑1b files for long‑term archival, a developer can use this C# code with Aspose.Imaging to ensure compliance.
 * 2. When a legal department needs to preserve vector graphics from EPS contracts as PDF/A‑1b documents for regulatory record‑keeping, the code provides a reliable conversion in .NET.
 * 3. When an e‑learning platform must transform EPS diagrams into searchable PDF/A‑1b files for accessibility and future proofing, this snippet automates the process.
 * 4. When a print‑to‑digital service needs to batch‑convert customer‑submitted EPS logos into PDF/A‑1b PDFs for secure online distribution, the example shows how to handle file validation and saving.
 * 5. When a document management system integrates C# code to ingest EPS files and store them as PDF/A‑1b compliant PDFs for metadata indexing, this approach ensures proper image loading and compliance settings.
 */