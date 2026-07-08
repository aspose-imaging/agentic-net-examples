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
            string outputPath = "output/Sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with PDF/A‑1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as a PDF file
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
 * 1. When a developer needs to convert legacy EPS artwork into PDF/A‑1b compliant PDFs for archival in a document management system.
 * 2. When a C# application must generate PDF reports from EPS logos while ensuring the output meets PDF/A‑1b standards required by regulatory agencies.
 * 3. When an automated build pipeline processes design assets and must transform EPS files into PDF/A‑1b PDFs for long‑term preservation.
 * 4. When a web service receives EPS files from users and must return PDF/A‑1b compliant PDFs for printing on certified printers.
 * 5. When a desktop utility needs to batch‑convert EPS diagrams to PDF/A‑1b PDFs to satisfy corporate sustainability documentation guidelines.
 */