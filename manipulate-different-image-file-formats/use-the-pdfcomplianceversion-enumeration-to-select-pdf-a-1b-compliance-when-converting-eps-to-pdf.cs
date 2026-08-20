// HOW-TO: Convert EPS to PDF/A‑1b Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

            // Verify that the input EPS file exists
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
                // Configure PDF options with PDF/A-1b compliance
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as a PDF/A-1b document
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
 * 1. When you need to archive vector graphics from EPS files in a PDF/A‑1b format for long‑term regulatory compliance.
 * 2. When a printing workflow requires converting EPS artwork to PDF/A‑1b to ensure color fidelity and PDF standards compliance.
 * 3. When an application must generate PDF/A‑1b documents from EPS logos for inclusion in electronic invoices or contracts.
 * 4. When a document management system needs to store EPS diagrams as searchable, standards‑compliant PDFs using C#.
 * 5. When you want to automate batch conversion of EPS files to PDF/A‑1b in a .NET service without manual intervention.
 */
