// HOW-TO: Convert EPS With Text To Searchable PDF/A-1b In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to searchable PDF
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Set PDF compliance (e.g., PDF/A-1b) to ensure searchable text
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
 * 1. When you need to archive vector graphics from design tools as searchable PDF/A‑1b documents for compliance.
 * 2. When an application must programmatically transform EPS logos that contain selectable text into PDF files that can be indexed by search engines.
 * 3. When a document management system requires converting incoming EPS files into searchable PDFs while preserving the original text objects.
 * 4. When generating printable reports that include EPS diagrams and you want the final PDF to allow text selection and copying.
 * 5. When automating batch processing of EPS assets to create PDF/A‑1b files that meet accessibility and long‑term preservation standards.
 */
