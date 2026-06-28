using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var pdfOptions = new PdfOptions();

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a developer needs to archive vector graphics from EPS files in a long‑term, standards‑compliant PDF/A‑2b format by setting PdfOptions.Compliance to PdfComplianceVersion.PdfA2b.
 * 2. When a printing workflow requires converting EPS artwork to PDF while guaranteeing PDF/A‑2b compliance via the PdfComplianceVersion enumeration to ensure consistent color and layout across different print vendors.
 * 3. When a digital publishing platform must transform EPS illustrations into PDF/A‑2b PDFs by using Aspose.Imaging’s PdfOptions with PdfComplianceVersion.PdfA2b so the documents remain viewable and searchable in PDF readers that enforce archival standards.
 * 4. When an enterprise document management system needs to ingest EPS logos and convert them to PDF/A‑2b PDFs, configuring PdfOptions.Compliance with PdfComplianceVersion.PdfA2b to meet corporate policy for searchable, self‑contained files.
 * 5. When a software solution for scientific journals converts EPS figures to PDF/A‑2b PDFs, applying the PdfComplianceVersion enumeration to satisfy journal submission guidelines that mandate PDF/A‑2b compliance for reproducibility and preservation.
 */