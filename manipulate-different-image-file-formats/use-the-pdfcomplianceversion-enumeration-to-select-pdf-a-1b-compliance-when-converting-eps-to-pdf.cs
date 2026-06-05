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

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with PDF/A‑1b compliance
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as PDF
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
 * 1. When a developer must archive vector graphics from EPS files in a PDF/A‑1b compliant format for long‑term preservation, they can use this code to convert and embed the EPS content into a PDF that meets ISO 19005‑1 standards.
 * 2. When an e‑commerce platform needs to generate legally compliant PDF invoices from EPS logos and diagrams, this snippet ensures the output PDF adheres to PDF/A‑1b requirements.
 * 3. When a document management system requires batch conversion of EPS illustrations to searchable PDFs that pass PDF/A‑1b validation for regulatory filing, the code provides a reliable C# solution.
 * 4. When a publishing workflow demands that all submitted EPS artwork be transformed into PDF/A‑1b PDFs before distribution to printers, this example automates the conversion while guaranteeing compliance.
 * 5. When a software vendor wants to offer a feature that exports EPS‑based reports as PDF/A‑1b files for secure electronic archiving, the provided code demonstrates the necessary Aspose.Imaging API usage.
 */