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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer uses Aspose.Imaging for .NET to convert legacy EPS files into PDF/A‑1b compliant PDFs for long‑term archival in a document management system.
 * 2. When an automated batch process written in C# needs to transform a collection of EPS artwork into searchable PDF/A‑1b documents to satisfy regulatory filing requirements.
 * 3. When a web API receives EPS uploads and must return PDF files that meet PDF/A‑1b archival standards using Aspose.Imaging’s PdfOptions.
 * 4. When a Windows desktop application processes design assets and must save them as PDF/A‑1b PDFs to ensure consistent rendering across PDF viewers, leveraging Aspose.Imaging’s image conversion.
 * 5. When a migration script moves print‑ready EPS files into a PDF/A‑1b archive to support electronic records retention policies, employing Aspose.Imaging for .NET.
 */