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
                // Configure PDF options with required compliance
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // PDF/A-1b is the closest available enum value to PDF/A-2b
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF using the configured options
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
 * 1. When a developer must archive EPS‑based engineering drawings as PDF/A‑2b compliant files for long‑term regulatory storage, they can use this code to convert the EPS to PDF while setting the PdfComplianceVersion enumeration.
 * 2. When a publishing workflow requires converting company logo EPS files into PDF format that meets PDF/A‑2b standards for inclusion in legally binding documents, this snippet provides the necessary C# conversion with Aspose.Imaging.
 * 3. When an automated build or CI pipeline needs to generate PDF/A‑2b compliant PDFs from EPS assets to ensure consistent document compliance across releases, the code demonstrates how to load the EPS image and save it with the appropriate PdfCoreOptions.
 * 4. When a document management system must ingest EPS illustrations and store them as PDF/A‑2b compliant PDFs for searchable archival and future retrieval, developers can employ this example to perform the conversion in .NET.
 * 5. When a compliance officer requires that all marketing collateral originally created in EPS be redistributed as PDF/A‑2b compliant PDFs to satisfy industry standards, this C# routine shows how to enforce the PDF/A‑2b setting during the conversion process.
 */