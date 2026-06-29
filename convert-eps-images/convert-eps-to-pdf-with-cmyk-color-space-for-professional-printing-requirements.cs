using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the EPS source file exists
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
                // Configure PDF options with PDF/A‑1b compliance (suitable for CMYK printing)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS as a PDF using the specified options
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print shop needs to convert client‑provided EPS artwork into PDF/A‑1b files with CMYK color space to meet professional printing standards using C# and Aspose.Imaging.
 * 2. When a desktop publishing application must batch‑process vector EPS logos into print‑ready PDFs while preserving color fidelity for offset printers.
 * 3. When an automated pre‑press workflow requires validating the existence of EPS source files and generating CMYK PDFs on the fly to comply with archival PDF/A compliance.
 * 4. When a .NET service integrates Aspose.Imaging to transform EPS design files into PDF documents that can be opened reliably in Adobe Acrobat for proofing.
 * 5. When a content management system needs to ensure that uploaded EPS files are safely converted to CMYK PDF/A‑1b output before distribution to commercial printers.
 */