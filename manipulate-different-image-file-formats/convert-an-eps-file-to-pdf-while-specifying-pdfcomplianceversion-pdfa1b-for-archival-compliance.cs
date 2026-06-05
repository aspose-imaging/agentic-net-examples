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
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        try
        {
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
                // Configure PDF options with PDF/A-1b compliance
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
 * 1. When a graphic design workflow requires converting EPS artwork to PDF for long‑term archival, a developer can use this code to produce PDF/A‑1b compliant documents.
 * 2. When an automated publishing system needs to batch‑process vector EPS files into searchable PDF files that meet regulatory compliance, the snippet shows how to enforce PDF/A‑1b during conversion.
 * 3. When a document management application must store client‑supplied EPS logos as PDF/A‑1b files to ensure they remain viewable in the future, this C# example demonstrates the required steps.
 * 4. When a .NET service integrates Aspose.Imaging to transform EPS schematics into PDF reports while guaranteeing PDF/A‑1b compliance for legal record‑keeping, the code provides the necessary implementation.
 * 5. When a cloud‑based conversion API has to validate that incoming EPS files are converted to PDF with PDF/A‑1b standards before delivery to downstream systems, this sample illustrates the process in C#.
 */