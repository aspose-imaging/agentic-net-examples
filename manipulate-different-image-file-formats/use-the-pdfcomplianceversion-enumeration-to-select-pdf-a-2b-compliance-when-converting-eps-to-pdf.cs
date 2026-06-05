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

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer uses the PdfComplianceVersion enumeration to convert EPS artwork into PDF/A‑2b compliant PDFs for long‑term archival in a document management system.
 * 2. When a developer must apply the PdfComplianceVersion enumeration to generate PDF/A‑2b files from EPS drawings to satisfy regulatory record‑keeping requirements in finance or healthcare.
 * 3. When a developer wants to embed EPS vector graphics into PDF/A‑2b PDFs by setting PdfComplianceVersion, ensuring the output passes PDF/A validation for print‑ready production.
 * 4. When a developer builds a C# batch‑processing tool that iterates over a folder of EPS files and uses PdfComplianceVersion to produce PDF/A‑2b PDFs for a digital asset repository.
 * 5. When a developer integrates Aspose.Imaging in a .NET web service that receives EPS uploads and, using PdfComplianceVersion, returns PDF/A‑2b compliant PDFs for downstream workflow automation.
 */