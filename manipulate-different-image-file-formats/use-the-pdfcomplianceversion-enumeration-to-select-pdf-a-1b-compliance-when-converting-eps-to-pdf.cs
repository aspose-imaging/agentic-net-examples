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
                using (var options = new PdfOptions())
                {
                    options.PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    };

                    image.Save(outputPath, options);
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
 * 1. When a developer needs to archive vector graphics from EPS files in a PDF/A‑1b compliant format for long‑term preservation, they can use Aspose.Imaging to convert EPS to PDF with PdfComplianceVersion.PdfA1b.
 * 2. When a printing workflow requires submitting PDF/A‑1b compliant documents to a regulatory authority, the code can convert incoming EPS artwork to PDF while enforcing the PDF/A‑1b standard.
 * 3. When a document management system must store searchable PDFs that meet ISO 19005‑1 (PDF/A‑1b) compliance, developers can use this C# snippet to transform EPS logos into compliant PDFs.
 * 4. When an automated batch process needs to generate PDF/A‑1b reports from EPS charts for legal e‑discovery, the PdfCoreOptions.PdfCompliance setting ensures each output PDF conforms to the required standard.
 * 5. When a cloud‑based API offers on‑the‑fly conversion of uploaded EPS files to PDF/A‑1b for clients who need archival‑ready PDFs, the provided code demonstrates how to set the PdfComplianceVersion enumeration in Aspose.Imaging for .NET.
 */