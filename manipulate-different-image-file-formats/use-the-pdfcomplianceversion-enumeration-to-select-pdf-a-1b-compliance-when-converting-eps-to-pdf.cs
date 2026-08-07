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
            // Hardcoded input and output paths
            string inputPath = "Sample.eps";
            string outputPath = "output/Sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PDF/A-1b
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

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
 * 1. When a developer needs to generate a PDF/A‑1b compliant archival PDF from an EPS logo for long‑term storage in a document management system.
 * 2. When a C# application must convert vector EPS artwork into a PDF that meets PDF/A‑1b standards for submission to a regulatory agency.
 * 3. When an automated build pipeline processes design assets and must ensure the resulting PDFs are PDF/A‑1b compliant for compatibility with enterprise content repositories.
 * 4. When a web service receives EPS files from users and must return PDF/A‑1b files that can be opened reliably in any PDF viewer without loss of image fidelity.
 * 5. When a desktop utility converts EPS schematics to PDF/A‑1b to embed them in electronic medical records that require strict PDF compliance.
 */