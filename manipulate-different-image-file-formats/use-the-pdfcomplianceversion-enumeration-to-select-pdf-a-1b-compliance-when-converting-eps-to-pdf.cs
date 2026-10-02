// HOW-TO: Convert EPS to PDF/A‑1b Compliant PDF in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
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
 * 1. When you need to archive vector graphics from EPS files in a PDF/A‑1b format for long‑term preservation or regulatory compliance.
 * 2. When a printing workflow requires converting EPS artwork to PDF while ensuring the output meets PDF/A‑1b standards for electronic document exchange.
 * 3. When an application must generate PDF/A‑1b documents from EPS logos to embed them in legally binding contracts.
 * 4. When a document management system imports EPS illustrations and stores them as PDF/A‑1b files to guarantee future accessibility.
 * 5. When a developer automates batch conversion of EPS designs to PDF/A‑1b compliant PDFs for submission to government or archival repositories.
 */
