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
        // Hardcoded input and output paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with required compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as high‑resolution PDF
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
 * 1. When a print shop needs to convert customer‑supplied EPS artwork that contains embedded raster images into a PDF/A‑1b compliant high‑resolution PDF for archival‑grade printing.
 * 2. When a publishing system must batch‑process vector EPS files from designers and generate print‑ready PDFs with preserved image quality for magazine layouts.
 * 3. When a CAD application exports drawings as EPS and a developer needs to provide a C# routine that turns those files into high‑resolution PDFs suitable for large‑format plotters.
 * 4. When an e‑commerce platform receives product packaging proofs in EPS format and must deliver PDF proofs that meet PDF/A compliance for regulatory review.
 * 5. When a document management workflow requires converting legacy EPS logos with embedded bitmaps into searchable, high‑resolution PDFs using Aspose.Imaging in a .NET environment.
 */