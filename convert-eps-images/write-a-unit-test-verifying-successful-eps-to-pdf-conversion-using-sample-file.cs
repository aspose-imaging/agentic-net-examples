// HOW-TO: Unit Test EPS to PDF Conversion With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

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

            // Load EPS image and convert to PDF
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                using (var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                })
                {
                    image.Save(outputPath, options);
                }
            }

            // Verify conversion succeeded
            if (File.Exists(outputPath))
            {
                Console.WriteLine("EPS to PDF conversion succeeded.");
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: output file not created.");
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
 * 1. When you need to automatically convert EPS artwork to PDF/A‑1b compliant documents in a C# backend service.
 * 2. When you must verify that an EPS to PDF conversion succeeds as part of a continuous integration pipeline.
 * 3. When your application processes user‑uploaded EPS files and must generate PDF previews for web display.
 * 4. When you require a reliable way to ensure the output PDF file is created before proceeding with further processing.
 * 5. When you want to integrate Aspose.Imaging’s PDF options to enforce PDF/A compliance during batch image conversions.
 */
