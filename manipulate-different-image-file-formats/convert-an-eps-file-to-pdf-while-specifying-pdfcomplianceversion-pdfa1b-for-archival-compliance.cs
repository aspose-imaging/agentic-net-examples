// HOW-TO: Convert EPS to PDF/A-1b Compliant PDF in C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
        // Hardcoded input and output file paths
        string inputPath = @"C:\Input\sample.eps";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with PDF/A-1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as PDF
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
 * 1. When you need to archive vector artwork from EPS files in a PDF/A‑1b format for long‑term preservation using C#.
 * 2. When a publishing workflow requires converting designer‑provided EPS logos to PDF/A‑1b compliant PDFs before embedding them into print‑ready documents.
 * 3. When an automated batch process must generate PDF/A‑1b compliant PDFs from EPS files to meet regulatory or industry standards.
 * 4. When a .NET application has to ensure that converted PDFs are searchable and meet PDF/A‑1b compliance for legal document storage.
 * 5. When integrating Aspose.Imaging into a C# service that transforms EPS graphics into PDF/A‑1b PDFs for cloud‑based document management systems.
 */
