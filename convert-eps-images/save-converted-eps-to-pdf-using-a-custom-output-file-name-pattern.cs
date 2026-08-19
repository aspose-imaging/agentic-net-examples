// HOW-TO: Convert EPS to PDF with Custom File Name in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.eps";
            string outputPath = Path.Combine(
                @"C:\Output",
                $"{Path.GetFileNameWithoutExtension(inputPath)}_converted.pdf");

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
                // Configure PDF options with desired compliance (optional)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF using the custom output path
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
 * 1. When you need to archive vector EPS artwork as PDF/A‑1b compliant files while preserving the original file name for easy reference.
 * 2. When an automated workflow must convert incoming EPS design files to PDFs and store them in a specific output folder with a “_converted” suffix.
 * 3. When a printing service requires PDFs generated from EPS logos and wants the output files to follow a consistent naming convention for batch processing.
 * 4. When a document management system imports EPS diagrams and you must save them as PDFs with a predictable filename pattern for indexing.
 * 5. When you are building a C# application that validates the existence of EPS files, creates missing directories, and converts them to PDFs using Aspose.Imaging.
 */
