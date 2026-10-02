// HOW-TO: Convert Eps To Pdf With Pdfa1b Compliance In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.eps";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfCoreOptions = new PdfCoreOptions { PdfCompliance = PdfComplianceVersion.PdfA1b };
                    epsImage.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to archive vector artwork from EPS files in a PDF/A‑1b compliant PDF for long‑term preservation.
 * 2. When a publishing workflow requires converting designer‑generated EPS logos to PDF while ensuring the output meets PDF/A‑1b standards for legal documents.
 * 3. When an automated batch process must transform EPS illustrations into PDF files that pass PDF/A‑1b validation for government submissions.
 * 4. When integrating Aspose.Imaging into a C# application to generate PDF reports that include EPS diagrams and must comply with archival PDF/A‑1b specifications.
 * 5. When migrating legacy EPS assets to PDF format and you need to enforce PDF/A‑1b compliance to guarantee compatibility with document management systems.
 */
