// HOW-TO: Convert EPS to PDF with PDF/A-1b Compliance in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and save as PDF with compliance options
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
 * 1. When a publishing workflow requires converting vector EPS artwork into archival‑grade PDF/A‑1b files for long‑term storage using C#.
 * 2. When an automated build process must generate print‑ready PDFs from EPS logos to embed in generated reports.
 * 3. When a document management system needs to ingest EPS files and store them as searchable PDF documents while preserving compliance standards.
 * 4. When a batch conversion tool has to transform a folder of EPS graphics into PDFs for distribution to clients who only accept PDF format.
 * 5. When a .NET application must validate that the resulting PDF meets PDF/A‑1b compliance before sending it to a regulatory authority.
 */
