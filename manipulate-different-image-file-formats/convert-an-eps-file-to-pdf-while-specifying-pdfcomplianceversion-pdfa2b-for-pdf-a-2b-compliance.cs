using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
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
 * 1. When a publishing system uses Aspose.Imaging for .NET to convert EPS files into PDF/A‑2b compliant PDFs for long‑term archival and regulatory compliance.
 * 2. When an e‑learning platform automatically transforms instructor‑provided EPS diagrams into PDF/A‑2b PDFs via C# code to guarantee consistent rendering on all devices.
 * 3. When a government agency processes engineering drawings stored as EPS and needs to generate PDF/A‑2b PDFs with Aspose.Imaging to ensure secure document exchange and ISO‑19005‑2 compliance.
 * 4. When a print‑on‑demand service converts customer‑uploaded EPS logos into PDF/A‑2b PDFs using Aspose.Imaging for .NET so the files can be embedded in print‑ready PDFs that meet archival standards.
 * 5. When a document management workflow ingests EPS artwork and creates PDF/A‑2b PDFs with Aspose.Imaging to enable searchable, searchable‑friendly storage while preserving vector quality and color profiles.
 */