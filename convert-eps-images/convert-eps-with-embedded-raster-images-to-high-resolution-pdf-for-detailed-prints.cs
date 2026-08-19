// HOW-TO: Convert EPS With Raster Images To High‑Resolution PDF/A‑1b In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with required compliance (e.g., PDF/A-1b)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS as a high‑resolution PDF
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
 * 1. When a designer needs to archive vector artwork that contains embedded photos as a print‑ready PDF/A‑1b document using C#.
 * 2. When a publishing workflow must transform EPS files from a legacy graphics system into high‑resolution PDFs for commercial printing.
 * 3. When an automated build process has to generate PDF proofs from EPS assets while preserving raster image quality.
 * 4. When a compliance‑focused application must convert EPS graphics to PDF/A‑1b to meet archival standards.
 * 5. When a .NET service needs to batch‑convert customer‑submitted EPS files into PDFs for preview in web browsers.
 */
