// HOW-TO: Convert EPS To PDF While Preserving Vector Paths In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;      // PdfOptions, PdfCoreOptions, PdfComplianceVersion
using Aspose.Imaging.FileFormats.Eps;      // EpsImage

class Program
{
    static void Main()
    {
        // All runtime errors are caught and reported
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

            // Load the EPS image as a vector image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options – keep vector data and set compliance if needed
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF while preserving vector paths
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF from an EPS logo without losing its edit‑able vector quality.
 * 2. When a printing workflow requires PDF/A‑1b compliance for archival while keeping the original EPS artwork scalable.
 * 3. When a web application must convert user‑uploaded EPS files to searchable PDFs without rasterizing the graphics.
 * 4. When automating batch processing of design assets, you want each EPS converted to a vector‑based PDF for downstream editing in Illustrator.
 * 5. When integrating Aspose.Imaging into a C# service that creates PDF reports from vector illustrations while preserving path data for later modifications.
 */
